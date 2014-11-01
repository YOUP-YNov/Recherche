﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class YoupDEVEntities : DbContext
    {
        public YoupDEVEntities()
            : base("name=YoupDEVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BLOG_Article> BLOG_Article { get; set; }
        public virtual DbSet<BLOG_Blog> BLOG_Blog { get; set; }
        public virtual DbSet<BLOG_Commentaire> BLOG_Commentaire { get; set; }
        public virtual DbSet<BLOG_HashTagArticle> BLOG_HashTagArticle { get; set; }
        public virtual DbSet<BLOG_Like> BLOG_Like { get; set; }
        public virtual DbSet<BLOG_Publicite> BLOG_Publicite { get; set; }
        public virtual DbSet<BLOG_Theme> BLOG_Theme { get; set; }
        public virtual DbSet<BLOG_Visite> BLOG_Visite { get; set; }
        public virtual DbSet<CONNECT_Authentification> CONNECT_Authentification { get; set; }
        public virtual DbSet<EVE_Etat> EVE_Etat { get; set; }
        public virtual DbSet<EVE_Evenement> EVE_Evenement { get; set; }
        public virtual DbSet<EVE_EvenementPhoto> EVE_EvenementPhoto { get; set; }
        public virtual DbSet<EVE_HashTagEvenement> EVE_HashTagEvenement { get; set; }
        public virtual DbSet<EVE_LieuEvenement> EVE_LieuEvenement { get; set; }
        public virtual DbSet<FOR_Forum> FOR_Forum { get; set; }
        public virtual DbSet<FOR_HashTagTopic> FOR_HashTagTopic { get; set; }
        public virtual DbSet<FOR_Message> FOR_Message { get; set; }
        public virtual DbSet<FOR_Sujet> FOR_Sujet { get; set; }
        public virtual DbSet<FOR_Topic> FOR_Topic { get; set; }
        public virtual DbSet<HC_Connexion> HC_Connexion { get; set; }
        public virtual DbSet<HC_Device> HC_Device { get; set; }
        public virtual DbSet<HR_Historique> HR_Historique { get; set; }
        public virtual DbSet<HR_Signaler> HR_Signaler { get; set; }
        public virtual DbSet<HR_Site> HR_Site { get; set; }
        public virtual DbSet<HR_TypeSignal> HR_TypeSignal { get; set; }
        public virtual DbSet<UT_Amis> UT_Amis { get; set; }
        public virtual DbSet<UT_Appreciation> UT_Appreciation { get; set; }
        public virtual DbSet<UT_Categorie> UT_Categorie { get; set; }
        public virtual DbSet<UT_Question> UT_Question { get; set; }
        public virtual DbSet<UT_Utilisateur> UT_Utilisateur { get; set; }
        public virtual DbSet<UT_Utilisateur_Aime_Categorie> UT_Utilisateur_Aime_Categorie { get; set; }
        public virtual DbSet<UT_Utilisateur_Invite_Evenement> UT_Utilisateur_Invite_Evenement { get; set; }
        public virtual DbSet<UT_Utilisateur_Note_Evenement> UT_Utilisateur_Note_Evenement { get; set; }
        public virtual DbSet<UT_Utilisateur_Participe_Evenement> UT_Utilisateur_Participe_Evenement { get; set; }
    
        public virtual ObjectResult<BLOG_GetAdByBlogId_Result> BLOG_GetAdByBlogId(Nullable<long> blogId)
        {
            var blogIdParameter = blogId.HasValue ?
                new ObjectParameter("BlogId", blogId) :
                new ObjectParameter("BlogId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetAdByBlogId_Result>("BLOG_GetAdByBlogId", blogIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetArticles_Result> BLOG_GetArticles(Nullable<long> utilisateurId, Nullable<long> blogId)
        {
            var utilisateurIdParameter = utilisateurId.HasValue ?
                new ObjectParameter("UtilisateurId", utilisateurId) :
                new ObjectParameter("UtilisateurId", typeof(long));
    
            var blogIdParameter = blogId.HasValue ?
                new ObjectParameter("BlogId", blogId) :
                new ObjectParameter("BlogId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetArticles_Result>("BLOG_GetArticles", utilisateurIdParameter, blogIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetArticlesByTag_Result> BLOG_GetArticlesByTag(string tag, Nullable<long> utilisateur_id)
        {
            var tagParameter = tag != null ?
                new ObjectParameter("Tag", tag) :
                new ObjectParameter("Tag", typeof(string));
    
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetArticlesByTag_Result>("BLOG_GetArticlesByTag", tagParameter, utilisateur_idParameter);
        }
    
        public virtual ObjectResult<BLOG_GetBlogById_Result> BLOG_GetBlogById(Nullable<long> blogId, Nullable<long> userId)
        {
            var blogIdParameter = blogId.HasValue ?
                new ObjectParameter("BlogId", blogId) :
                new ObjectParameter("BlogId", typeof(long));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetBlogById_Result>("BLOG_GetBlogById", blogIdParameter, userIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetBlogs_Result> BLOG_GetBlogs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetBlogs_Result>("BLOG_GetBlogs");
        }
    
        public virtual ObjectResult<BLOG_GetBlogsByCategory_Result> BLOG_GetBlogsByCategory(Nullable<long> categoryId)
        {
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetBlogsByCategory_Result>("BLOG_GetBlogsByCategory", categoryIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetBlogsBySearch_Result> BLOG_GetBlogsBySearch(Nullable<long> category, string keyString)
        {
            var categoryParameter = category.HasValue ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(long));
    
            var keyStringParameter = keyString != null ?
                new ObjectParameter("KeyString", keyString) :
                new ObjectParameter("KeyString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetBlogsBySearch_Result>("BLOG_GetBlogsBySearch", categoryParameter, keyStringParameter);
        }
    
        public virtual ObjectResult<BLOG_GetCategories_Result> BLOG_GetCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetCategories_Result>("BLOG_GetCategories");
        }
    
        public virtual ObjectResult<BLOG_GetCommentaireById_Result> BLOG_GetCommentaireById(Nullable<long> commentaireId)
        {
            var commentaireIdParameter = commentaireId.HasValue ?
                new ObjectParameter("CommentaireId", commentaireId) :
                new ObjectParameter("CommentaireId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetCommentaireById_Result>("BLOG_GetCommentaireById", commentaireIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetCommentaires_Result> BLOG_GetCommentaires(Nullable<long> articleId)
        {
            var articleIdParameter = articleId.HasValue ?
                new ObjectParameter("ArticleId", articleId) :
                new ObjectParameter("ArticleId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetCommentaires_Result>("BLOG_GetCommentaires", articleIdParameter);
        }
    
        public virtual ObjectResult<BLOG_GetPromotedBlogs_Result> BLOG_GetPromotedBlogs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetPromotedBlogs_Result>("BLOG_GetPromotedBlogs");
        }
    
        public virtual ObjectResult<BLOG_GetThemeById_Result> BLOG_GetThemeById(Nullable<long> themeId)
        {
            var themeIdParameter = themeId.HasValue ?
                new ObjectParameter("ThemeId", themeId) :
                new ObjectParameter("ThemeId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BLOG_GetThemeById_Result>("BLOG_GetThemeById", themeIdParameter);
        }
    
        public virtual ObjectResult<string> BLOG_LikeArticle(Nullable<long> article_id, Nullable<long> utilisateur_id)
        {
            var article_idParameter = article_id.HasValue ?
                new ObjectParameter("Article_id", article_id) :
                new ObjectParameter("Article_id", typeof(long));
    
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("BLOG_LikeArticle", article_idParameter, utilisateur_idParameter);
        }
    
        public virtual ObjectResult<string> BLOG_PromoteBlog(Nullable<long> userId, Nullable<bool> promoted)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            var promotedParameter = promoted.HasValue ?
                new ObjectParameter("Promoted", promoted) :
                new ObjectParameter("Promoted", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("BLOG_PromoteBlog", userIdParameter, promotedParameter);
        }
    
        public virtual ObjectResult<string> BLOG_ReportCommentaire(Nullable<long> userId, Nullable<long> commentaireId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            var commentaireIdParameter = commentaireId.HasValue ?
                new ObjectParameter("CommentaireId", commentaireId) :
                new ObjectParameter("CommentaireId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("BLOG_ReportCommentaire", userIdParameter, commentaireIdParameter);
        }
    
        public virtual ObjectResult<string> desmontrerere()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("desmontrerere");
        }
    
        public virtual ObjectResult<ps_GetAllCategorie_Result> ps_GetAllCategorie(Nullable<long> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetAllCategorie_Result>("ps_GetAllCategorie", idParameter);
        }
    
        public virtual ObjectResult<ps_GetAllEvenement_Result> ps_GetAllEvenement()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetAllEvenement_Result>("ps_GetAllEvenement");
        }
    
        public virtual ObjectResult<ps_GetEvenementById_Result> ps_GetEvenementById(Nullable<long> identifiant)
        {
            var identifiantParameter = identifiant.HasValue ?
                new ObjectParameter("Identifiant", identifiant) :
                new ObjectParameter("Identifiant", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetEvenementById_Result>("ps_GetEvenementById", identifiantParameter);
        }
    
        public virtual ObjectResult<ps_GetEventByCateg_Result> ps_GetEventByCateg(string categorie, Nullable<System.DateTime> dateDebut, Nullable<System.DateTime> dateFin)
        {
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            var dateDebutParameter = dateDebut.HasValue ?
                new ObjectParameter("DateDebut", dateDebut) :
                new ObjectParameter("DateDebut", typeof(System.DateTime));
    
            var dateFinParameter = dateFin.HasValue ?
                new ObjectParameter("DateFin", dateFin) :
                new ObjectParameter("DateFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetEventByCateg_Result>("ps_GetEventByCateg", categorieParameter, dateDebutParameter, dateFinParameter);
        }
    
        public virtual ObjectResult<ps_GetEventByCategAndCP_Result> ps_GetEventByCategAndCP(Nullable<int> cP, string categorie)
        {
            var cPParameter = cP.HasValue ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(int));
    
            var categorieParameter = categorie != null ?
                new ObjectParameter("Categorie", categorie) :
                new ObjectParameter("Categorie", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetEventByCategAndCP_Result>("ps_GetEventByCategAndCP", cPParameter, categorieParameter);
        }
    
        public virtual ObjectResult<ps_GetEventByCP_Result> ps_GetEventByCP(Nullable<int> cP)
        {
            var cPParameter = cP.HasValue ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetEventByCP_Result>("ps_GetEventByCP", cPParameter);
        }
    
        public virtual ObjectResult<ps_GetEventByProfil_Result> ps_GetEventByProfil(Nullable<long> profil_id)
        {
            var profil_idParameter = profil_id.HasValue ?
                new ObjectParameter("profil_id", profil_id) :
                new ObjectParameter("profil_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetEventByProfil_Result>("ps_GetEventByProfil", profil_idParameter);
        }
    
        public virtual ObjectResult<ps_GetImage_Result> ps_GetImage(Nullable<int> eventId)
        {
            var eventIdParameter = eventId.HasValue ?
                new ObjectParameter("EventId", eventId) :
                new ObjectParameter("EventId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetImage_Result>("ps_GetImage", eventIdParameter);
        }
    
        public virtual ObjectResult<ps_GetLieuEvenementByCodePostale_Result> ps_GetLieuEvenementByCodePostale(Nullable<int> cP)
        {
            var cPParameter = cP.HasValue ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetLieuEvenementByCodePostale_Result>("ps_GetLieuEvenementByCodePostale", cPParameter);
        }
    
        public virtual ObjectResult<ps_GetLieuEvenementById_Result> ps_GetLieuEvenementById(Nullable<long> lieuEvenementId)
        {
            var lieuEvenementIdParameter = lieuEvenementId.HasValue ?
                new ObjectParameter("LieuEvenementId", lieuEvenementId) :
                new ObjectParameter("LieuEvenementId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetLieuEvenementById_Result>("ps_GetLieuEvenementById", lieuEvenementIdParameter);
        }
    
        public virtual ObjectResult<ps_GetLieuEvenementByVille_Result> ps_GetLieuEvenementByVille(string ville)
        {
            var villeParameter = ville != null ?
                new ObjectParameter("Ville", ville) :
                new ObjectParameter("Ville", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_GetLieuEvenementByVille_Result>("ps_GetLieuEvenementByVille", villeParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetAmisByUtilisateur_Result> ps_UT_GetAmisByUtilisateur(Nullable<int> utilisateur_id)
        {
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetAmisByUtilisateur_Result>("ps_UT_GetAmisByUtilisateur", utilisateur_idParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetCategorieByUtilisateur_Result> ps_UT_GetCategorieByUtilisateur(Nullable<int> utilisateur_id)
        {
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetCategorieByUtilisateur_Result>("ps_UT_GetCategorieByUtilisateur", utilisateur_idParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetEvenementCreateByUtilisateur_Result> ps_UT_GetEvenementCreateByUtilisateur(Nullable<int> utilisateur_id)
        {
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("utilisateur_id", utilisateur_id) :
                new ObjectParameter("utilisateur_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetEvenementCreateByUtilisateur_Result>("ps_UT_GetEvenementCreateByUtilisateur", utilisateur_idParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetParticipeEventByUtilisateur_Result> ps_UT_GetParticipeEventByUtilisateur(Nullable<int> utilisateur_id)
        {
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetParticipeEventByUtilisateur_Result>("ps_UT_GetParticipeEventByUtilisateur", utilisateur_idParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetTenProfilUtilisateur_Result> ps_UT_GetTenProfilUtilisateur()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetTenProfilUtilisateur_Result>("ps_UT_GetTenProfilUtilisateur");
        }
    
        public virtual ObjectResult<ps_UT_GetTopEvent_Result> ps_UT_GetTopEvent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetTopEvent_Result>("ps_UT_GetTopEvent");
        }
    
        public virtual ObjectResult<ps_UT_GetUtilisateurByEmailPasswd_Result> ps_UT_GetUtilisateurByEmailPasswd(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetUtilisateurByEmailPasswd_Result>("ps_UT_GetUtilisateurByEmailPasswd", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetUtilisateurById_Result> ps_UT_GetUtilisateurById(Nullable<int> utilisateur_id)
        {
            var utilisateur_idParameter = utilisateur_id.HasValue ?
                new ObjectParameter("Utilisateur_id", utilisateur_id) :
                new ObjectParameter("Utilisateur_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetUtilisateurById_Result>("ps_UT_GetUtilisateurById", utilisateur_idParameter);
        }
    
        public virtual ObjectResult<ps_UT_GetUtilisateurs_Result> ps_UT_GetUtilisateurs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_UT_GetUtilisateurs_Result>("ps_UT_GetUtilisateurs");
        }
    }
}