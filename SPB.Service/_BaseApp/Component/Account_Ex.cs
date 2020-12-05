
namespace BaseApp.Service
{
    internal class EmailFields
    {
        public string subject { get; set; }
        public string bodyHtml { get; set; }
        public string bodyText { get; set; }

        public static EmailFields Build_Invitation(string url)
        {
            var line1 = "Vous êtes invité à joindre l'application SPB par votre administrateur.";
            var line2 = "Cliquez ce lien pour créer un mot de passe:";
            var line3 = "Ce lien est valide pour une durée de une semaine.";

            var subject = $"OpsFMS Invitation";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }

        public static EmailFields Build_ResetPasswordBy_Admin(string url)
        {
            var line1 = "Votre administrateur SPB exige que vous changiez de mot de passe.";
            var line2 = "Cliquez ce lien pour créer un nouveau mot de passe:";
            var line3 = "Ce lien est valide pour une durée de une semaine.";

            var subject = $"Nouveau mot de passe exigé";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }

        public static EmailFields Build_ResetPasswordBy_Self(string url)
        {
            var line1 = "Réparons ce problème de mot de passe!";
            var line2 = "Cliquez ce lien pour créer un nouveau mot de passe:";
            var line3 = "Ce lien est valide pour une durée de une semaine.";
            var line4 = "NOTE: Vous n'avez qu'à ignorer ce courriel si vous n'avez pas demandé ce courriel";

            var subject = $"Demande de nouveau mot de passe";
            var bodyHtml = $@"
                <div style='padding: 10px;'>
                    <p>{line1}</p>
                    <p>{line2}<br/>
                        <a href='{url}'>{url}</a>
                    </p>
                    <p>{line3}</p>
                    <p>{line4}</p>
                </div>
            ";
            var bodyText = $@"{line1}

{line2}
{url}

{line3}

{line4}
";

            return new EmailFields
            {
                subject = subject,
                bodyHtml = bodyHtml,
                bodyText = bodyText
            };
        }
    }
}