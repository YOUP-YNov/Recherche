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
    
    public partial class BLOG_Blog
    {
        public BLOG_Blog()
        {
            this.BLOG_Article = new HashSet<BLOG_Article>();
            this.BLOG_Publicite = new HashSet<BLOG_Publicite>();
            this.BLOG_Visite = new HashSet<BLOG_Visite>();
        }
    
        public long Blog_id { get; set; }
        public long Utilisateur_id { get; set; }
        public string TitreBlog { get; set; }
        public System.DateTime DateCreation { get; set; }
        public long Categorie_id { get; set; }
        public bool Actif { get; set; }
        public bool Promotion { get; set; }
        public long Theme_id { get; set; }
    
        public virtual ICollection<BLOG_Article> BLOG_Article { get; set; }
        public virtual UT_Categorie UT_Categorie { get; set; }
        public virtual BLOG_Theme BLOG_Theme { get; set; }
        public virtual UT_Utilisateur UT_Utilisateur { get; set; }
        public virtual ICollection<BLOG_Publicite> BLOG_Publicite { get; set; }
        public virtual ICollection<BLOG_Visite> BLOG_Visite { get; set; }
    }
}
