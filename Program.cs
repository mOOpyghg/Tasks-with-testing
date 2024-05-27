using System;
using InsuranceCompany.Services;
 
class Program
{
    static void Main(string[] args)
    {
        BranchService branchService = new BranchService();
        CustomerService customerService = new CustomerService();
        PolicyService policyService = new PolicyService();
 
        // Пример использования сервисов
        branchService.CreateBranch("Central Branch", "123 Main St", "+1234567890");
        customerService.CreateCustomer("John Doe", "123-45-6789");
        policyService.CreatePolicy("2024-05-16", 100000, "Auto Insurance", 0.05, "Central Branch");
 
        // Ввод нового филиала пользователем
        Console.WriteLine("Введите название филиала:");
        string name = Console.ReadLine();
        Console.WriteLine("Введите адрес филиала:");
        string address = Console.ReadLine();
        Console.WriteLine("Введите телефон филиала:");
        string phone = Console.ReadLine();
 
        try
        {
            branchService.CreateBranch(name, address, phone);
            Console.WriteLine("Новый филиал добавлен успешно.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}