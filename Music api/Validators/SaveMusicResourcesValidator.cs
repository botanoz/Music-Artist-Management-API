using FluentValidation;
using Music.api.DTO;

namespace Music.api.Validators
{
    public class SaveMusicResourcesValidator : AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicResourcesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(50);
            RuleFor(x=>x.ArtistId).NotEmpty().WithMessage("Artist id must not be empty");

        }
    }
}
