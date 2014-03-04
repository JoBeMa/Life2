/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import java.util.Properties;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.mail.*;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.InternetAddress;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class MailUtils {

	static Logger log = LoggerFactory.getLogger(MailUtils.class);
	
	/**
	 * Envia un mail con todos los campos, incluyendo una lista de cco (copias ocultas)
	 * @param subject
	 * @param text
	 * @param to
	 * @param from
	 * @param cc
	 * @throws MessagingException
	 */
	public static void sendMail(String subject, String text, String to, String from, String[] cco) throws MessagingException
	{
		Properties properties = new Properties();
		String smtp=PropertyManager.getInstance().getSmtpServer();
		String smtpPort=PropertyManager.getInstance().getSmtpServerPort();
		properties.setProperty("mail.smtp.host", smtp);
		if (PropertyManager.getInstance().enableTLS())
			properties.setProperty("mail.smtp.starttls.enable", "true");

		properties.setProperty("mail.smtp.port", ""+smtpPort);
		
		if (PropertyManager.getInstance().useIdentification())
		{
			properties.setProperty("mail.smtp.user", PropertyManager.getInstance().getSmtpUser());
			properties.setProperty("mail.smtp.auth", "true");		
		}
		if (to==null || from==null)
			throw new MessagingException("Los campos to y from no pueden ser nulos");
		Session session = Session.getDefaultInstance(properties);
		session.setDebug(true);
		Message message = new MimeMessage(session);
		message.setFrom(new InternetAddress(from));
		message.setRecipient(Message.RecipientType.TO,new InternetAddress(to));
		if (cco!=null && cco.length>0)
		{
			for (int i=0;i<cco.length;i++)
				message.addRecipient(Message.RecipientType.BCC, new InternetAddress(cco[i]));
		}
		message.setSubject(subject);
		message.setText(text); 
		if (PropertyManager.getInstance().useIdentification())
		{
			Transport t = session.getTransport("smtp");		
			t.connect(PropertyManager.getInstance().getSmtpUser(),PropertyManager.getInstance().getSmtpPwd());
			t.sendMessage(message,message.getAllRecipients());	
			t.close();
		}
		else
			Transport.send(message);		
		log.debug("sendMail: Mail send to "+to);
	}
	
	/**
	 * Envia un mensaje sin copias
	 * @param subject
	 * @param text
	 * @param to
	 * @param from
	 * @throws MessagingException
	 */
	public static void sendMail(String subject, String text, String to, String from) throws MessagingException
	{
		sendMail( subject,  text,  to,  from,null);
	}
	
	public static boolean  isEmail(String correo) {
        Pattern pat = null;
        Matcher mat = null;        
        pat = Pattern.compile("^[\\w\\-\\_\\+]+(\\.[\\w\\-\\_]+)*@([A-Za-z0-9-]+\\.)+[A-Za-z]{2,4}$");
        mat = pat.matcher(correo);
        if (mat.find()) {
            System.out.println("[" + mat.group() + "]");
            return true;
        }else{
            return false;
        }        
    }
	
	public static boolean isValidEmail(String email)
	{
		return email.matches("^[\\w\\-\\_\\+]+(\\.[\\w\\-\\_]+)*@([A-Za-z0-9-]+\\.)+[A-Za-z]{2,4}$");
	}
	
	
	
}
