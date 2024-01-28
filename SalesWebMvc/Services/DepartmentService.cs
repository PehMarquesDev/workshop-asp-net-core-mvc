using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Declaração de método assíncrono
        //Operações assíncronas ocorrem sem a necessidade de pausar o resto do programa
        // enquanto ela estiver sendo executada
        public async Task<List<Department>> FindAllAsync()
        {
            //Caso fosse uma operação normal, a execução seria interrompida até o momento em que ele fizesse o return
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
