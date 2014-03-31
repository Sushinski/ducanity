using System;

namespace DukappCore.BL.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class,
                           AllowMultiple = true)  // multiuse attribute
    ]
    public class ManyToMany : System.Attribute
    {
        public string m_relTableName;
        public string m_relTableField;
        public ManyToMany( string rel_table_name, string rel_table_field )
        {
            m_relTableName = rel_table_name;
            m_relTableField = rel_table_field;
        }
    }
}

