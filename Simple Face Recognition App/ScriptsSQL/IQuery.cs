using APS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.ScriptsSQL
{
    public interface IQuery
    {
        List<AgrotoxicosEntity> GetAllByName();
    }
}
