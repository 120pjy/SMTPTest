using System;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;

var message = new MimeMessage();
message.From.Add(new MailboxAddress("Daniel the Awesome", "someone@rapidfiretools.com"));
message.To.Add(new MailboxAddress("Senor Mischievous", @"someone@gmail
.com"));
message.Subject = "Declaration of War on Japan";
message.Body = new TextPart("plain")
{
    Text =
        @"
JOINT RESOLUTION Declaring that a state of war exists between the Imperial Government of Japan and the Government and the people of the United States and making provisions to prosecute the same.

Whereas the Imperial Government of Japan has committed unprovoked acts of war against the Government and the people of the United States of America:

Therefore be it Resolved by the Senate and House of Representatives of the United States of America in Congress assembled, That the state of war between the United States and the Imperial Government of Japan which has thus been thrust upon the United States is hereby formally declared; and the President is hereby authorized and directed to employ the entire naval and military forces of the United States and the resources of the Government to carry on war against the Imperial Government of Japan; and, to bring the conflict to a successful termination, all the resources of the country are hereby pledged by the Congress of the United States.

(Signed) Sam Rayburn, Speaker of the House of Representatives

(Signed) H. A. Wallace, Vice President of the United States and President of the Senate

Approved December 11, 1941 3:05 PM E.S.T.

(Signed) Daniel Park"
};

using (var client = new SmtpClient())
{

    client.Connect("", 587, SecureSocketOptions.Auto);
    client.Authenticate("rftadmin@rapidfiretools.com", "password");
    client.Send(message);
    client.Disconnect(true);
}