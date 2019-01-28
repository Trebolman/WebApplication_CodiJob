using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CustomDTO
{
    public class AddUserDTO
    {
        /*public Guid ID { get; set; }*/
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Git { get; set; }
        public string Blog { get; set; }
        public string Web { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
