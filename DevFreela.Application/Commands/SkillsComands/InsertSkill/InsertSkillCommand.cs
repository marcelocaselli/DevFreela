using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.SkillsComands.InsertSkill
{
    public class InsertSkillCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }
    }
}
