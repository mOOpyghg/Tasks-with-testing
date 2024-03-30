using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Spark.Sql;
using static Microsoft.Spark.Sql.Functions;

namespace ProductCategoryPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            SparkSession spark = SparkSession
                .Builder()
                .AppName("ProductCategoryPairs")
                .GetOrCreate();

            
            DataFrame result = GetProductCategoryPairsWithNullCategories(spark, productsDf, categoriesDf);

            
            result.Show();

            spark.Stop();
        }

        static DataFrame GetProductCategoryPairsWithNullCategories(SparkSession spark, DataFrame productsDf, DataFrame categoriesDf)
        {
            
            DataFrame joinedDf = productsDf
                .Join(categoriesDf, productsDf["product_id"] == categoriesDf["product_id"], "left_outer");

            
            DataFrame resultDf = joinedDf.Select(productsDf["product_name"], categoriesDf["category_name"]);

            
            DataFrame nullCategoriesDf = joinedDf.Filter(col("category_id").IsNull())
                                                  .Select(productsDf["product_name"])
                                                  .Distinct();

            
            resultDf = resultDf.Union(nullCategoriesDf.WithColumn("category_name", Lit(null)).WithColumn("has_category", Lit(false)));

            return resultDf;
        }
    }
}
