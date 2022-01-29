using FluentValidation;
using System;

namespace Travely.ReportingManager.Grpc.Models
{
    public class BaseToDoModel
    {
        public string Name { get; set; }
        public int? TourId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? Reminder { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public byte Priority { get; set; }
    }

    public class CreateToDoModel : BaseToDoModel
    {

    }

    public class UpdateToDoModel : BaseToDoModel
    {
        public int Id { get; set; }
    }

    public class CreateToDoModelValidator : AbstractValidator<CreateToDoModel>
    {
        public CreateToDoModelValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(4, 50);

            RuleFor(p => p.Deadline)
                .Cascade(CascadeMode.Stop).NotEmpty().WithMessage("{PropertyName} is Empty")
                .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Invalid Date Time");

            RuleFor(p => p.Reminder)
               .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Invalid Date Time");

            RuleFor(p => p.Description)
               .Length(0, 1000);

            //RuleFor(p => p.Status)
            //.NotEmpty().WithMessage("{PropertyName} is Empty").IsInEnum().WithMessage("{PropertyName} incorrect");

            //RuleFor(p => p.Priority)
            //.NotEmpty().WithMessage("{PropertyName} is Empty").IsInEnum().WithMessage("{PropertyName} incorrect"); 
        }
    }

    public class UpdateToDoModelValidator : AbstractValidator<UpdateToDoModel>
    {
        public UpdateToDoModelValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is Empty");

            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(4, 50).WithMessage("Lenght ({TotalLenght}) of {PropertyName} Invalid");

            RuleFor(p => p.Deadline)
                .Cascade(CascadeMode.Stop).NotEmpty().WithMessage("{PropertyName} is Empty")
                .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Invalid Date Time");

            RuleFor(p => p.Reminder)
               .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Invalid Date Time");

            RuleFor(p => p.Description)
               .Length(0, 1000).WithMessage("Lenght ({TotalLenght}) of {PropertyName} Invalid");

            //RuleFor(p => p.Status)
            //.NotEmpty().WithMessage("{PropertyName} is Empty").IsInEnum().WithMessage("{PropertyName} incorrect");

            //RuleFor(p => p.Priority)
            //.NotEmpty().WithMessage("{PropertyName} is Empty").IsInEnum().WithMessage("{PropertyName} incorrect"); 
        }
    }
}
