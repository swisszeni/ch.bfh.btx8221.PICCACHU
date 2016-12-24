using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class MaintenanceInstruction : IKnowledgeBaseEntry
    {
        public MaintenanceInstruction(string title, List<MaintenanceInstructionStep> instructionSteps)
        {
            Title = title;
            InstructionSteps = instructionSteps;
        }

        public string Title { get; }

        public List<MaintenanceInstructionStep> InstructionSteps { get; }
    }
}
