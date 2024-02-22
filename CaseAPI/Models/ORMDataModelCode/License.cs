using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace CaseAPI.Models.caseproj
{

    public partial class License
    {
        public License(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
