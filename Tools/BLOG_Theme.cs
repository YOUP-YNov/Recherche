//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tools
{
    using System;
    using System.Collections.Generic;
    
    public partial class BLOG_Theme
    {
        public BLOG_Theme()
        {
            this.BLOG_Blog = new HashSet<BLOG_Blog>();
        }
    
        public long Theme_id { get; set; }
        public string Couleur { get; set; }
        public string ImageChemin { get; set; }
    
        public virtual ICollection<BLOG_Blog> BLOG_Blog { get; set; }
    }
}
