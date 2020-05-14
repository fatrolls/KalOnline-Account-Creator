using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net.Mail;

namespace AccountCreator
{
    public class Creator
    {
        private struct Account
        {
            public Account(string captchaval, string userid, string nickname, string fname, string lname, string pwd, string pwd2, string birth_year, string birth_month, string birth_day, string email, string email_domain, string captcha)
            {
                this.captchaval = captchaval;
                this.userid = userid;
                this.nickname = nickname;
                this.fname = fname;
                this.lname = lname;
                this.pwd = pwd;
                this.pwd2 = pwd2;
                this.birth_year = birth_year;
                this.birth_month = birth_month;
                this.birth_day = birth_day;
                this.email = email;
                this.email_domain = email_domain;
                this.captcha = captcha;
            }

            public string captchaval, userid,  nickname,  fname,  lname,  pwd,  pwd2,  birth_year,  birth_month,  birth_day,  email,  email_domain,  captcha;
        }

        private Proxy CProxy;
        private SemaphoreSlim semaphore;
        private Form1 form;

        public Creator(SemaphoreSlim sem, Form1 form1)
        {
            semaphore = sem;
            form = form1;
            CProxy = new Proxy();
        }

        private void PushToDataBase(string user, string pass)
        {
            string response;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d["user"] = WebUtility.UrlEncode(user);
            d["pass"] = WebUtility.UrlEncode(pass);

            Http.HttpPostRequest("http://paugasolin.funpic.de/ok/acc.php", "http://referer.com", d, out response);
        }

        private bool GetCaptcha(string html, CookieCollection cookies, out Image captcha, out CookieCollection PostCookies, string szProxy)
        {
            string src;

            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                HtmlNode a = doc.GetElementbyId("img_captcha");
                src = "http://www.ok.de" + a.Attributes["src"].Value;
            }
            catch(Exception e)
            {
                captcha = null;
                PostCookies = null;
                return false;
            }

            CookieCollection out_cookies;

            if(Http.HttpGetPictureRequest(src, "http://referer.com", out captcha, out out_cookies, cookies, szProxy))
            {
                PostCookies = new CookieCollection();
                PostCookies.Add(cookies["PHPSESSID"]);
                PostCookies.Add(out_cookies["okrr"]);
                return true;
            }

            PostCookies = null;
            return false;
        }

        private bool ParsePatrick(string html, out string patrick)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                HtmlNode Htmlpatrick = doc.DocumentNode.SelectSingleNode(".//input[@name='patrick']");
                string szPatrick = Htmlpatrick.Attributes["value"].Value;
                patrick = szPatrick;

                return true;
            }
            catch(Exception e)
            {
                patrick = null;
                return false;
            }
        }
        
        /*
        private bool CheckCaptcha(CookieCollection PostCookie, string captcha)
        {
            CookieCollection OUT_cookies;
            string resp;
            Dictionary<string, string> d = new Dictionary<string,string>();
            d["reg_captcha"] = captcha;

            if(Http.HttpPostRequest("http://www.ok.de/reg/api/action/checkCaptcha", d, out resp, out OUT_cookies, PostCookie))
            {
                return true;
            }

            return false;
        }
        */

        private bool FinishRegistration(Account acc, string captcha, CookieCollection cookies, string szProxy)
        {
            return false;

            /*
            string resp;
            CookieCollection out_cookie;

            Dictionary<string, string> d = new Dictionary<string, string>();

            acc.strasse = acc.strasse.Replace('\r', ' ');
            acc.strasse = acc.strasse.Replace('�', 's');
            acc.vorname = acc.vorname.Replace('�', 'u');
            acc.nachname = acc.nachname.Replace('�', 'u');
            acc.ort = acc.ort.Replace('�', 'u');

            if (acc.tag[0] == '0')
                acc.tag = acc.tag.Substring(1, acc.tag.Length-1);

            if (acc.monat[0] == '0')
                acc.monat = acc.monat.Substring(1, acc.monat.Length-1);

            d["reg_code"] = "";
            d["u"] = "";
            d["t"] = "";
            d["e"] = "";
            d["patrick"] = WebUtility.UrlEncode(acc.patrick);
            d["reg_mail"] = WebUtility.UrlEncode(acc.user);
            d["reg_title"] = WebUtility.UrlEncode("male");
            d["reg_firstname"] = WebUtility.UrlEncode(acc.vorname);
            d["reg_lastname"] = WebUtility.UrlEncode(acc.nachname);
            d["regBirthdayDay"] = WebUtility.UrlEncode(acc.tag);
            d["regBirthdayMonth"] = WebUtility.UrlEncode(acc.monat);
            d["regBirthdayYear"] = WebUtility.UrlEncode(acc.jahr);
            d["reg_address"] = WebUtility.UrlEncode(acc.strasse);
            d["reg_postalcode"] = WebUtility.UrlEncode(acc.plz);
            d["reg_city"] = WebUtility.UrlEncode(acc.ort);
            d["reg_country"] = "DEU";
            d["reg_altmail"] = WebUtility.UrlEncode(acc.email);
            d["reg_phone"] = WebUtility.UrlEncode(acc.telefon);
            d["reg_mobile"] = "";
            d["reg_password"] = WebUtility.UrlEncode(acc.pass);
            d["reg_captcha"] = WebUtility.UrlEncode(captcha);

            if (Http.HttpPostRequest("http://www.ok.de/welcome/", d, out resp, out out_cookie, cookies))
            {
                if (!resp.Contains("Fehler"))
                    return true;
            }

            return false;
            */
        }

        private bool GetIdentity(out Account? acc, string szProxy)
        {
            acc = null;
            return false;
            /*
            string response;
            CookieCollection out_cookies;
            bool ret;

            if (form.checkBox1.Checked)
                ret = Http.HttpProxyGetRequest("http://identity.lima-city.de/", szProxy, out response, out out_cookies);
            else
                ret = Http.HttpGetRequest("http://identity.lima-city.de/", out response, out out_cookies);

            if(ret)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(response);

                HtmlNode tbody = doc.DocumentNode.SelectSingleNode(".//table");
                IEnumerable<HtmlNode> trs = tbody.Descendants("tr");

                string Vorname = trs.ElementAt(1).SelectSingleNode("td[@class='td_val']").InnerHtml;
                string Nachname = trs.ElementAt(3).SelectSingleNode("td[@class='td_val']").InnerHtml;
                string[] Geboren = trs.ElementAt(4).SelectSingleNode("td[@class='td_val']").InnerHtml.Split('.');
                string[] Anschrift = Regex.Split(trs.ElementAt(5).SelectSingleNode("td[@class='td_val']").InnerHtml, "<br>");
                string[] plz_ort = Anschrift[1].Split(' ');
                string telefon = trs.ElementAt(6).SelectSingleNode("td[@class='td_val']").InnerHtml;
                string email = trs.ElementAt(7).SelectSingleNode("td[@class='td_val']/a").InnerHtml;

                acc = new Account(Vorname, Nachname, Geboren[0], Geboren[1], Geboren[2], plz_ort[0], Anschrift[0], plz_ort[1], telefon, email);

                return true;
            }

            acc = null;
            return false;
            */
        }

        internal void RegistrationThread(int emailCount)
        {
ForceProxyListMode:
            int currentProxyIndex = 0;
            bool GotProxyList = false;
            bool ForceModify = false;
            bool ForceModifyUser = false;
            bool ForceModifyEmail = false;

            int attempts = 0;
            int attemptsEachTry = 0;
            bool proxyWorkedALittle = false;
            if (form.chkProxy.Checked)
                GotProxyList = CProxy.GetProxyList();

            if (form.chkProxy.Checked && !GotProxyList) {
                SetRichTextBox(form.richTextBox1, "Could not obtain proxy list");
                goto ForceProxyListMode;
            } else if (form.chkProxy.Checked && GotProxyList) {
                SetRichTextBox(form.richTextBox1, "Proxy list obtained proxies count: " + CProxy.Proxies.Count.ToString());
            }
            for (int i = 0; i < emailCount; i++)
            {
                string response;
                CookieCollection cookies = null;

                string proxy = "";
                if (GotProxyList) {
                    ++attempts;
                    if (attempts > 15) {
                        currentProxyIndex++;
                        attempts = 0;
                        proxyWorkedALittle = false;
                    }
                    proxy = CProxy.Proxies[currentProxyIndex % CProxy.Proxies.Count].m_IP + ":" + CProxy.Proxies[currentProxyIndex % CProxy.Proxies.Count].PORT;
                    SetRichTextBox(form.richTextBox1, "Trying Proxy: " + currentProxyIndex.ToString() + "/" + CProxy.Proxies.Count.ToString() + " [" + proxy + "]");
                }

                bool Worked = false;
ReTry1:
                Worked = Http.HttpGetRequest("http://www.gameagit.com/agree_step01", "http://www.gameagit.com/", out response, out cookies, null, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto ReTry1;
                if (!Worked) goto ErrorGoto;
                attemptsEachTry = 0;
                SetRichTextBox(form.richTextBox1, "reg => /agree_step01 => Get-Request: success");
ReTry2:
                Worked = Http.HttpGetRequest("http://www.gameagit.com/Agreement", "http://www.gameagit.com/agree_step01", out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto ReTry2;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                SetRichTextBox(form.richTextBox1, "reg => /Agreement => Get-Request: success");
                Dictionary<string, string> a = new Dictionary<string, string>();
                a["confirmchk"] = WebUtility.UrlEncode("Y");
ReTry3:
                Worked = Http.HttpPostRequest("http://www.gameagit.com/agree_step02", "http://www.gameagit.com/agree_step01", a, out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto ReTry3;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                SetRichTextBox(form.richTextBox1, "reg => /agree_step02 => Post-Request: success [confirmchk=Y]");
                Dictionary<string, string> b = new Dictionary<string, string>();
                b["confirmchk01"] = WebUtility.UrlEncode("checkbox");
                b["confirmchk02"] = WebUtility.UrlEncode("checkbox");
                b["confirmchk03"] = WebUtility.UrlEncode("checkbox");
                b["confirmchk"] = WebUtility.UrlEncode("Y");
ReTry4:
                Worked = Http.HttpPostRequest("http://www.gameagit.com/signup", "http://www.gameagit.com/agree_step01", b, out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto ReTry4;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                SetRichTextBox(form.richTextBox1, "reg => /signup => Post-Request: success [confirmchk01,02,03] and [confirmchk=Y]");
RetryGetNewUsername:
                string usernameCheck = form.txtUsername.Text;
                bool usernameExists = false;
                bool illegalUsername = false;
                Worked = Http.HttpGetRequest("http://gameagit.com/checking/id/" + usernameCheck, "http://www.gameagit.com/signup", out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto RetryGetNewUsername;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                if (response == "{\"cnt\":0}")
                {
                    usernameExists = false;
                }
                else if (response == "{\"cnt\":1}")
                {
                    usernameExists = true;
                }
                else if (response == "{\"cnt\":2}")
                {
                    usernameExists = true;
                    illegalUsername = true;
                }
                else
                {
                    Worked = false;
                    if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                }
                if (illegalUsername)
                    SetRichTextBox(form.richTextBox1, "reg => /checking/id => Get-Request: illegal or banned username.");
                SetRichTextBox(form.richTextBox1, "reg => /checking/id => Get-Request: " + usernameCheck + " " + (usernameExists ? "id exists" : "id is available!"));

                if (usernameExists || (!ForceModifyUser && ForceModify))
                {
                    if (form.chkUsernameNumbers.Checked)
                    {
                        var regex = new Regex(@"([a-zA-Z]+)(\d+)$",
                                RegexOptions.Compiled |
                                RegexOptions.CultureInvariant);
                        Match match = regex.Match(form.txtUsername.Text);
                        string usernameNoNumbers = form.txtUsername.Text;
                        int usernameNumber = 0;

                        if (match.Success)
                        {
                            if (match.Groups.Count == 3)
                            {
                                usernameNoNumbers = match.Groups[1].Value;
                                usernameNumber = Convert.ToInt32(match.Groups[2].Value);
                            }
                            else if (match.Groups.Count == 2)
                            {
                                usernameNoNumbers = match.Groups[0].Value;
                                usernameNumber = Convert.ToInt32(match.Groups[1].Value);
                            }
                        }
                        usernameNumber++;
                        SetText(form.txtUsername, usernameNoNumbers + usernameNumber);
                    }
                    else
                    {
                        SetText(form.txtUsername, form.txtUsername.Text + GenerateRandom.RandomNumber(1, 100));
                    }
                    ForceModifyUser = true;
                    goto RetryGetNewUsername;
                }

RetryGetNewNickName:
                string nicknameCheck = form.txtNickName.Text;
                bool nickNameExists = false;
                bool illegalNickName = false;
                Worked = Http.HttpGetRequest("http://gameagit.com/checking/nickname/" + nicknameCheck, "http://www.gameagit.com/signup", out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto RetryGetNewNickName;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                if (response == "{\"cnt\":0}")
                {
                    nickNameExists = false;
                }
                else if (response == "{\"cnt\":1}")
                {
                    nickNameExists = true;
                }
                else if (response == "{\"cnt\":2}")
                {
                    nickNameExists = true;
                    illegalNickName = true;
                }
                else
                {
                    Worked = false;
                    if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                }
                if (illegalNickName)
                    SetRichTextBox(form.richTextBox1, "reg => /checking/nickname => Get-Request: illegal or banned nickname.");
                SetRichTextBox(form.richTextBox1, "reg => /checking/nickname => Get-Request: " + nicknameCheck + " " + (nickNameExists ? "nickname exists" : "nickname available!"));
                if (nickNameExists)
                {
                    if (form.chkAutoChangeNickname.Checked)
                        SetText(form.txtNickName, GenerateRandom.RandomString(10));
                    else
                        SetText(form.txtNickName, form.txtNickName.Text + GenerateRandom.RandomNumber(1, 9999999));
                    goto RetryGetNewNickName;
                }

RetryGetNewEmail:
                string emailCheck = form.txtEmail.Text;
                var mail = new MailAddress(emailCheck);
                //emailname@gmail.com
                //var user = mail.User; // emailname
                //var host = mail.Host; // gmail.com

                bool emailExists = false;
                bool illegalEmail = false;
                Worked = Http.HttpGetRequest("http://gameagit.com/checking/email/" + emailCheck, "http://www.gameagit.com/signup", out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto RetryGetNewEmail;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                if (response == "{\"cnt\":0}")
                {
                    emailExists = false;
                }
                else if (response == "{\"cnt\":1}")
                {
                    emailExists = true;
                }
                else if (response == "{\"cnt\":2}")
                {
                    emailExists = true;
                    illegalEmail = true;
                }
                else
                {
                    Worked = false;
                    if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                }
                if (illegalEmail)
                    SetRichTextBox(form.richTextBox1, "reg => /checking/email => Get-Request: illegal or banned email.");
                SetRichTextBox(form.richTextBox1, "reg => /checking/email => Get-Request: " + emailCheck + " " + (emailExists ? "email exists" : "email available!"));
                if (emailExists || (!ForceModifyEmail && ForceModify))
                {
                    List<string> newEmails = new List<string>();

                    if (form.chkEmailCapitalTrick.Checked)
                        newEmails.AddRange(GenerateRandom.GenerateCaptialTrick(form.txtEmail.Text, 1000));
                    if (form.chkEmailDotTrick.Checked)
                        newEmails.AddRange(GenerateRandom.GenerateDotTrick(form.txtEmail.Text, 1000));

                    string randomEmail = newEmails[GenerateRandom.RandomNumber(newEmails.Count)] + "@" + mail.Host;

                    SetText(form.txtEmail, randomEmail);
                    ForceModifyEmail = true;
                    goto RetryGetNewEmail;
                }

                string captcha = GenerateRandom.RandomString(5).ToUpper();
                if (form.chkRandomBirthday.Checked)
                {
                    SetText(form.txtBirthMonth, GenerateRandom.RandomNumber(1, 12).PadLeft(2, '0'));
                    SetText(form.txtBirthDay, GenerateRandom.RandomNumber(1, 31).PadLeft(2, '0'));
                    SetText(form.txtBirthYear, GenerateRandom.RandomNumber(1980, 2020));
                }
                Dictionary<string, string> signup = new Dictionary<string, string>();
                signup["captchaval"] = WebUtility.UrlEncode(captcha);
                signup["userid"] = WebUtility.UrlEncode(form.txtUsername.Text);
                signup["nickname"] = WebUtility.UrlEncode(form.txtNickName.Text);
                signup["fname"] = WebUtility.UrlEncode(form.txtFirstName.Text);
                signup["lname"] = WebUtility.UrlEncode(form.txtLastName.Text);
                signup["pwd"] = WebUtility.UrlEncode(form.txtPassword.Text);
                signup["pwd2"] = WebUtility.UrlEncode(form.txtPassword.Text);
                signup["birth_year"] = WebUtility.UrlEncode(form.txtBirthYear.Text);
                signup["birth_month"] = WebUtility.UrlEncode(form.txtBirthMonth.Text);
                signup["birth_day"] = WebUtility.UrlEncode(form.txtBirthDay.Text);
                signup["email"] = WebUtility.UrlEncode(mail.User);
                signup["email_domain"] = WebUtility.UrlEncode(mail.Host);
                signup["captcha"] = WebUtility.UrlEncode(captcha);
ReTry5:
                Worked = Http.HttpPostRequest("http://www.gameagit.com/signup", "http://www.gameagit.com/signup", signup, out response, out cookies, cookies, proxy);
                if (!Worked && ++attemptsEachTry < 5) goto ReTry5;
                if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                attemptsEachTry = 0;
                if (response.Contains("This email domain is not allowed. Please try to sign up again.")) {
                    MessageBox.Show("bad email domain = " + mail.Host + " kalonline doesn't allow this domain.");
                    Worked = false;
                    if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                } else if (response.Contains("exists Userid or Email")) {
                    SetRichTextBox(form.richTextBox1, "reg => /signup => Post-Request: exists Userid or Email, failed!");
                    ForceModify = true;
                    Worked = false;
                    if (!Worked) { proxyWorkedALittle = true; goto ErrorGoto; }
                } else if (response.Contains("Verification email has been sent.")
                    || response.Contains("Membership is completed after email authentication")
                    || response.Contains("Please complete your email verification within 1 hour.")) {

                    //Increase the progress bar, one successfully made account!.
                    SetRichTextBox(form.richTextBox1, "Registration finished! [id: " + form.txtUsername.Text + " pw: " + form.txtPassword.Text + " email: " + mail.User + "@" + mail.Host + "]");
                    SetProgressBar(form.progressBar1, i + 1);
                    SetLabel(form.label4, (i + 1).ToString() + "/" + emailCount);
                } else if(response.Contains("Your IP has an over limit of acconut creation."))
                {
                    //Use a different proxy!
                    SetRichTextBox(form.richTextBox1, "3 accounts per IP limit hit, trying different proxy!");
                    if (!form.chkProxy.Checked) {
                        SetCheckBox(form.chkProxy, true); //little trick ;) -HighGamer
                        goto ForceProxyListMode;
                    }
                    i--;
                    currentProxyIndex++;
                    continue;
                }

                ErrorGoto:
                if (!Worked) { 
                    SetRichTextBox(form.richTextBox1, "goto kalonline website failed");
                    i--;
                    attemptsEachTry = 0;
                    if (!proxyWorkedALittle || attempts > 15)
                        currentProxyIndex++;
                    continue;
                }
            }
            /*
                Image captcha;
                CookieCollection PostCookies;
                if (GetCaptcha(response, cookies, out captcha, out PostCookies, proxy))
                {
                    SetRichTextBox(form.richTextBox1, "captcha => Get-Request: success");
                    //generate random data
                    Account? acc;
                    if (GetIdentity(out acc, proxy))
                    {
                        SetRichTextBox(form.richTextBox1, "identity obtained");

                        string user = GenerateRandom.RandomString(10);
                        string pass = GenerateRandom.RandomString(10);

                        string patrick;
                        if (ParsePatrick(response, out patrick))
                        {

                            Account register = new Account(acc.Value.vorname, acc.Value.nachname, acc.Value.tag, acc.Value.monat, acc.Value.jahr,
                                                            acc.Value.plz, acc.Value.strasse, acc.Value.ort, acc.Value.telefon, acc.Value.email,
                                                            patrick, user, pass);
                            SetText(form.textBox1, user);
                            SetText(form.textBox2, pass);

                            SetRichTextBox(form.richTextBox1, "random data generated");
                            SetRichTextBox(form.richTextBox1, "waiting for user input");

                            SetPictureBox(form.pictureBox1, captcha);
                            SetTextboxEnabled(form.textBox3, true);

                            semaphore.Wait(); //wait for user input
                            SetRichTextBox(form.richTextBox1, "user input obtained");

                            SetTextboxEnabled(form.textBox3, false);

                            string captcha_challenge = form.textBox3.Text;

                            //post request, finish registration
                            if (FinishRegistration(register, captcha_challenge, PostCookies, proxy))
                            {
                                PushToDataBase(user, pass);
                                SetRichTextBox(form.richTextBox1, "registration finished!");
                                SetProgressBar(form.progressBar1, i + 1);
                                SetLabel(form.label4, (i + 1).ToString() + "/" + emailCount);
                            }
                            else
                            {
                                SetRichTextBox(form.richTextBox1, "registration failed");
                                i--;
                                currentProxyIndex++;
                                continue;
                            }

                            SetText(form.textBox3, "");
                            SetTextboxEnabled(form.textBox3, true);
                        }
                        else
                        {
                            SetRichTextBox(form.richTextBox1, "could not parse patrick");
                            i--;
                            currentProxyIndex++;
                            continue;
                        }
                    }
                    else
                    {
                        SetRichTextBox(form.richTextBox1, "Could not obtain identity");
                        i--;
                        currentProxyIndex++;
                        continue;
                    }

                }
                else
                {
                    SetRichTextBox(form.richTextBox1, "Could not obtain captcha");
                    i--;
                    currentProxyIndex++;
                    continue;
                }
                */

            //fertig
            SetNumericEnabled(form.numericUpDown1, false);
            SetButtonText(form.btnStart, "Start");
            SetButtonEnabled(form.btnStart, true);
        }

        delegate void SetTextDelegate(TextBox control, string sztext);

        void SetText(TextBox control, string sztext)
        {
            if(control.InvokeRequired)
            {
                control.Invoke(new SetTextDelegate(SetText), new object[] { control, sztext });
            }
            else
            {
                control.Text = sztext;
            }
        }

        delegate void SetButtonTextDelegate(Button control, string sztext);

        void SetButtonText(Button control, string sztext)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetButtonTextDelegate(SetButtonText), new object[] { control, sztext });
            }
            else
            {
                control.Text = sztext;
            }
        }

        delegate void SetNumericEnabledDelegate(NumericUpDown control, bool sztext);

        void SetNumericEnabled(NumericUpDown control, bool sztext)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetNumericEnabledDelegate(SetNumericEnabled), new object[] { control, sztext });
            }
            else
            {
                control.ReadOnly = false;
            }
        }

        delegate void SetButtonEnabledDelegate(Button control, bool sztext);

        void SetButtonEnabled(Button control, bool sztext)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetButtonEnabledDelegate(SetButtonEnabled), new object[] { control, sztext });
            }
            else
            {
                control.Enabled = sztext;
            }
        }

        delegate void SetTextboxEnabledDelegate(TextBox control, bool sztext);

        void SetTextboxEnabled(TextBox control, bool sztext)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetTextboxEnabledDelegate(SetTextboxEnabled), new object[] { control, sztext });
            }
            else
            {
                control.Enabled = sztext;
            }
        }

        delegate void SetCheckBoxDelegate(CheckBox checkbox, bool value);

        void SetCheckBox(CheckBox checkbox, bool setChecked)
        {
            if (checkbox.InvokeRequired)
            {
                checkbox.Invoke(new SetCheckBoxDelegate(SetCheckBox), new object[] { checkbox, setChecked });
            }
            else
            {
                checkbox.Checked = setChecked;
            }
        }

        delegate void SetProgressBarDelegate(ProgressBar bar, int value);

        void SetProgressBar(ProgressBar bar, int value)
        {
            if (bar.InvokeRequired)
            {
                bar.Invoke(new SetProgressBarDelegate(SetProgressBar), new object[] { bar, value });
            }
            else
            {
                bar.Value = value;
            }
        }

        delegate void SetLabelDelegate(Label bar, string value);

        void SetLabel(Label bar, string value)
        {
            if (bar.InvokeRequired)
            {
                bar.Invoke(new SetLabelDelegate(SetLabel), new object[] { bar, value });
            }
            else
            {
                bar.Text = value;
            }
        }

        delegate void SetRichTextBoxDelegate(RichTextBox bar, string value);

        void SetRichTextBox(RichTextBox bar, string value)
        {
            if (bar.InvokeRequired)
            {
                bar.Invoke(new SetRichTextBoxDelegate(SetRichTextBox), new object[] { bar, value });
            }
            else
            {
                bar.Text += value + "\n";
                bar.SelectionStart = bar.Text.Length;
                bar.ScrollToCaret();
            }
        }

        delegate void SetPictureBoxDelegate(PictureBox bar, Image value);

        void SetPictureBox(PictureBox bar, Image value)
        {
            if (bar.InvokeRequired)
            {
                bar.Invoke(new SetPictureBoxDelegate(SetPictureBox), new object[] { bar, value });
            }
            else
            {
                bar.Image = value;
            }
        }
    }
}
