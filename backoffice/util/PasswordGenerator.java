/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import java.nio.ByteBuffer;
import java.nio.CharBuffer;
import java.nio.charset.CharacterCodingException;
import java.nio.charset.Charset;
import java.nio.charset.CharsetDecoder;
import java.nio.charset.CharsetEncoder;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.regex.Pattern;

import org.hibernate.annotations.TypeDef;

public class PasswordGenerator {
		 
		public static String NUMEROS = "0123456789";
	 
		public static String MAYUSCULAS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	 
		public static String MINUSCULAS = "abcdefghijklmnopqrstuvwxyz";
	 
		public static String ESPECIALES = "–„";
	 
		//Contra–as de 4
		public static String getPinNumber() {
			return getPassword(NUMEROS, 4);
		}
		//Contrase–as de 8
		public static String getPassword() {
			return getPassword(8);
		}
	 
		public static String getPassword(int length) {
			String pwd=getPassword(NUMEROS + MAYUSCULAS + MINUSCULAS, length);
			while (!isSecure(pwd))
				pwd=getPassword(NUMEROS + MAYUSCULAS + MINUSCULAS, length);
			return pwd;
		}
	 
		private static String getPassword(String key, int length) {
			String pswd = "";
	 
			for (int i = 0; i < length; i++) {
				pswd+=(key.charAt((int)(Math.random() * key.length())));
			} 
			return pswd;
		}
		
		
		public static boolean isSecure(String pwd) {
			Pattern mayusculas=Pattern.compile("[A-Z]+");
			Pattern minusculas=Pattern.compile("[a-z]+");
			Pattern numeros=Pattern.compile("[0-9]+");
			return mayusculas.matcher(pwd).find()&&minusculas.matcher(pwd).find()&&numeros.matcher(pwd).find();
		}
		
		
		public static String createHash(String data){
	        MessageDigest digest;
	        StringBuffer sb = new StringBuffer();
			try {
				digest = MessageDigest.getInstance("SHA-256");
		        digest.update(data.getBytes());
		        byte byteData[] = digest.digest();
		        //convert bytes to hex chars
		        
		        for (int i = 0; i < byteData.length; i++) {
		         sb.append(Integer.toString((byteData[i] & 0xff) + 0x100, 16).substring(1));
		        }
			} catch (NoSuchAlgorithmException e) {
			}

	        return sb.toString();
		}		
		
		
		public static String utf8Decoder(String text)
		{
			return utf8Decoder(text.getBytes());
		}
		
		public static String utf8Decoder(byte[] text)
		{
			Charset charset = Charset.forName("UTF-8");
			CharsetDecoder decoder = charset.newDecoder();
			Charset charset2 = Charset.forName("ISO-8859-1");
			
			String result="";
			try {
			    // Convert a string to ISO-LATIN-1 bytes in a ByteBuffer
			    // The new ByteBuffer is ready to be read.
			    ByteBuffer bbuf = ByteBuffer.wrap(text);

			    // Convert ISO-LATIN-1 bytes in a ByteBuffer to a character ByteBuffer and then to a string.
			    // The new ByteBuffer is ready to be read.
			    CharBuffer cbuf = decoder.decode(bbuf);
			    result = cbuf.toString();
			} catch (CharacterCodingException e) {
				e.printStackTrace();
			}
			return result;
		}	
		
		
		public static String utf8Encoder(String text)
		{
			Charset charset = Charset.forName("UTF-8");
			CharsetEncoder encoder = charset.newEncoder();
			String result="";
			try {
			    // Convert a string to ISO-LATIN-1 bytes in a ByteBuffer
			    // The new ByteBuffer is ready to be read.
			    ByteBuffer bbuf = encoder.encode(CharBuffer.wrap(text));
			    result = bbuf.toString();
			} catch (CharacterCodingException e) {
			}
			return result;
		}	
		
		public static String isoDecoder(String text)
		{
			Charset charset = Charset.forName("ISO-8859-1");
			CharsetDecoder decoder = charset.newDecoder();
			String result="";
			try {
			    // Convert a string to ISO-LATIN-1 bytes in a ByteBuffer
			    // The new ByteBuffer is ready to be read.
			    ByteBuffer bbuf = ByteBuffer.wrap(text.getBytes());

			    // Convert ISO-LATIN-1 bytes in a ByteBuffer to a character ByteBuffer and then to a string.
			    // The new ByteBuffer is ready to be read.
			    CharBuffer cbuf = decoder.decode(bbuf);
			    result = cbuf.toString();
			} catch (CharacterCodingException e) {
			}
			return result;
		}
		
		public static String isoEncoder(String text)
		{
			Charset charset = Charset.forName("ISO-8859-1");
			CharsetEncoder encoder = charset.newEncoder();
			CharsetDecoder decoder = charset.newDecoder();
			String result="";
			try {
			    // Convert a string to ISO-LATIN-1 bytes in a ByteBuffer
			    // The new ByteBuffer is ready to be read.
			    ByteBuffer bbuf = encoder.encode(CharBuffer.wrap(text));
			    result = decoder.decode(bbuf).toString();
			} catch (CharacterCodingException e) {
			}
			return result;
		}			
		
	}

