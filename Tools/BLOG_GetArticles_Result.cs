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
    
    public partial class BLOG_GetArticles_Result
    {
        public long Article_id { get; set; }
        public long Blog_id { get; set; }
        public string TitreArticle { get; set; }
        public string ImageChemin { get; set; }
        public string ContenuArticle { get; set; }
        public Nullable<long> Evenement_id { get; set; }
        public System.DateTime DateCreation { get; set; }
        public Nullable<System.DateTime> DateModification { get; set; }
        public bool Actif { get; set; }
        public Nullable<long> HashTagArticle_id { get; set; }
        public string Mots { get; set; }
        public bool IsLiked { get; set; }
    }
}
