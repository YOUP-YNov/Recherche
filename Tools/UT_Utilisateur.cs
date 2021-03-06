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
    
    public partial class UT_Utilisateur
    {
        public UT_Utilisateur()
        {
            this.BLOG_Blog = new HashSet<BLOG_Blog>();
            this.BLOG_Commentaire = new HashSet<BLOG_Commentaire>();
            this.BLOG_Like = new HashSet<BLOG_Like>();
            this.BLOG_Visite = new HashSet<BLOG_Visite>();
            this.CONNECT_Authentification = new HashSet<CONNECT_Authentification>();
            this.EVE_Evenement = new HashSet<EVE_Evenement>();
            this.FOR_Message = new HashSet<FOR_Message>();
            this.FOR_Topic = new HashSet<FOR_Topic>();
            this.HC_Connexion = new HashSet<HC_Connexion>();
            this.HR_Signaler = new HashSet<HR_Signaler>();
            this.UT_Amis = new HashSet<UT_Amis>();
            this.UT_Amis1 = new HashSet<UT_Amis>();
            this.UT_Appreciation = new HashSet<UT_Appreciation>();
            this.UT_Appreciation1 = new HashSet<UT_Appreciation>();
            this.UT_Question = new HashSet<UT_Question>();
            this.UT_Utilisateur_Invite_Evenement = new HashSet<UT_Utilisateur_Invite_Evenement>();
            this.UT_Utilisateur_Invite_Evenement1 = new HashSet<UT_Utilisateur_Invite_Evenement>();
            this.UT_Utilisateur_Aime_Categorie = new HashSet<UT_Utilisateur_Aime_Categorie>();
            this.UT_Utilisateur_Participe_Evenement = new HashSet<UT_Utilisateur_Participe_Evenement>();
            this.UT_Utilisateur_Note_Evenement = new HashSet<UT_Utilisateur_Note_Evenement>();
        }
    
        public long Utilisateur_id { get; set; }
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }
        public System.DateTime DateInscription { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Sexe { get; set; }
        public string AdresseMail { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string PhotoChemin { get; set; }
        public string Situation { get; set; }
        public bool Actif { get; set; }
        public bool Partenaire { get; set; }
        public string Presentation { get; set; }
        public string Metier { get; set; }
    
        public virtual ICollection<BLOG_Blog> BLOG_Blog { get; set; }
        public virtual ICollection<BLOG_Commentaire> BLOG_Commentaire { get; set; }
        public virtual ICollection<BLOG_Like> BLOG_Like { get; set; }
        public virtual ICollection<BLOG_Visite> BLOG_Visite { get; set; }
        public virtual ICollection<CONNECT_Authentification> CONNECT_Authentification { get; set; }
        public virtual ICollection<EVE_Evenement> EVE_Evenement { get; set; }
        public virtual ICollection<FOR_Message> FOR_Message { get; set; }
        public virtual ICollection<FOR_Topic> FOR_Topic { get; set; }
        public virtual ICollection<HC_Connexion> HC_Connexion { get; set; }
        public virtual ICollection<HR_Signaler> HR_Signaler { get; set; }
        public virtual ICollection<UT_Amis> UT_Amis { get; set; }
        public virtual ICollection<UT_Amis> UT_Amis1 { get; set; }
        public virtual ICollection<UT_Appreciation> UT_Appreciation { get; set; }
        public virtual ICollection<UT_Appreciation> UT_Appreciation1 { get; set; }
        public virtual ICollection<UT_Question> UT_Question { get; set; }
        public virtual ICollection<UT_Utilisateur_Invite_Evenement> UT_Utilisateur_Invite_Evenement { get; set; }
        public virtual ICollection<UT_Utilisateur_Invite_Evenement> UT_Utilisateur_Invite_Evenement1 { get; set; }
        public virtual ICollection<UT_Utilisateur_Aime_Categorie> UT_Utilisateur_Aime_Categorie { get; set; }
        public virtual ICollection<UT_Utilisateur_Participe_Evenement> UT_Utilisateur_Participe_Evenement { get; set; }
        public virtual ICollection<UT_Utilisateur_Note_Evenement> UT_Utilisateur_Note_Evenement { get; set; }
    }
}
