using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntryImageElement : IKnowledgeEntryElement
    {
        Image source;
        public string Caption { get; set; }

        // Constructor with an image and a caption element
        public KnowledgeEntryImageElement(Image aSource, string aCaption)
        {
            source = aSource;
            Caption = aCaption;
        }

        // Constructor with only an image provided.
        public KnowledgeEntryImageElement(Image aSource)
        {
            source = aSource;

        }

        object IKnowledgeEntryElement.element
        {
            get
            {
                return source;
            }
        }

        string IKnowledgeEntryElement.type
        {
            get
            {
                return "image";
            }
        }
    }
}
