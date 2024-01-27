using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        //ViewModel onde serão passados os parâmetros necessários para o View Create de Sellers
        //Essa é a maneira de passar mais de um objeto, relacionados, ou não ao View
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }

        
    }
}
