﻿namespace Crud.API.Dtos
{
    public class NewPersonRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
