using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.sys
{
    [TargetTbale]
    [Serializable]
    public class XT_DATA_COLUMN:BaseModel
    {
        [TargetColumn]
        public string TABLE_NAME { get; set; }
    }
}
