using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class QuestionEntity : BaseEntity, IDelete
{
    public string? Title {  get; set; }
    public string? OptionOne {  get; set; }
    public string? OptionTwo {  get; set; }
    public string? OptionThree {  get; set; }
    public string? OptionFour {  get; set; }



    public bool IsDeleted { get; set ; }=false;
}
