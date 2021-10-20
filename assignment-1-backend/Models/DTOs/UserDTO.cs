using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Models.DTOs
{
    public class UserDTO
    {
        public Guid? UserID { get; set; }
        [Required(ErrorMessage = "Name cannot be empty", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Birthday is mandatory")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Address is mandatory", AllowEmptyStrings = false)]
        public string Address { get; set; }
        public int RoleID { get; set; }

        public static UserDTO FromEntity(User user)
        {
            return new UserDTO
            {
               // UserID = user.ID,
                Name = user.Name,
                Birthday = user.Birthday,
                Address = user.Address,
               // RoleID = user.RoleID
            };
        }

        public static User FromModel(UserDTO userDTO)
        {
            return new User
            {
              //  ID = userDTO.UserID ?? Guid.NewGuid(),
                Name = userDTO.Name,
                Birthday = userDTO.Birthday,
                Address = userDTO.Address,
              //  RoleID = userDTO.RoleID
            };
        }
    }
}
