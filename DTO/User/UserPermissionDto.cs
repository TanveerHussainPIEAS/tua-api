namespace TUAApi.DTO.User
{
    public class UserPermissionDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool CanAddProduct { get; set; }

        public bool CanEditProduct { get; set; }

        public bool CanViewProduct { get; set; }

        public bool CanDeleteProduct { get; set; }

        public bool CanAddOrder { get; set; }

        public bool CanEditOrder { get; set; }

        public bool CanViewOrder { get; set; }

        public bool CanDeleteOrder { get; set; }

        public bool CanAddUser { get; set; }

        public bool CanEditUser { get; set; }

        public bool CanViewUser { get; set; }

        public bool CanDeleteUser { get; set; }
    }
}
