using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand contact)
        { var  value= await _repository.GetByIdAsync(contact.ContactID);
            if (value == null)
                throw new Exception("Güncellenecek değer  bulunamadı");
            {
                value.Name = contact.Name;
                value.Email = contact.Email;
                value.Subject = contact.Subject;
                value.Message = contact.Message;
                value.SendDate = contact.SendDate;
                await _repository.UpdateAsync(value);
            }
        }
    }
}
