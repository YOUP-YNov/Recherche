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
    
    public partial class BLOG_HashTagArticle
    {
        public long HashTagArticle_id { get; set; }
        public long Article_id { get; set; }
        public string Mots { get; set; }
    
        public virtual BLOG_Article BLOG_Article { get; set; }
    }
}
