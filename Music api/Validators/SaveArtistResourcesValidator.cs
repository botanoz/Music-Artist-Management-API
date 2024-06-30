using FluentValidation;
using Music.api.DTO;

namespace Music.api.Validators
{
    public class SaveArtistResourcesValidator : AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourcesValidator()
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .Length(50);

           
        }
    }
}
