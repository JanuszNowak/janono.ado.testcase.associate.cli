using System;

namespace janono.ado.testcase.associate.cli
{
    public class Association
    {
        public Association()
        {
        }

        public string Organization { get; set; }

        public string Assembly { get; set; }

        public string Method { get; set; }

        public int TestCaseId { get; set; }

        public Guid AutomatedTestId { get; set; }

        public bool NeedUpdateInsert { get; set; }

        public string StatusCode { get; internal set; }
    }
}
