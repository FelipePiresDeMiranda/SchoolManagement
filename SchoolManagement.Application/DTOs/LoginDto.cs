using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs.Auth
{
    public class LoginDto
    {        
        public required string Email { get; set; }        
        public required string Senha { get; set; }
    }
}