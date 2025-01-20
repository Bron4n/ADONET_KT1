using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ADONET_KT1.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                ViewData["Message"] = "Сообщение не может быть пустым!";
            }
            else
            {
                int shift = 33;
                string encryptedMessage = CaesarCipherEncrypt(message, shift);
                ViewData["Message"] = $"Зашифрованное сообщение: {encryptedMessage}";
            }

            return View();
        }

        private string CaesarCipherEncrypt(string input, int shift)
        {
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string lowerAlphabet = alphabet.ToLower();

            Dictionary<char, char> cipherMap = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                cipherMap[alphabet[i]] = alphabet[(i + shift) % alphabet.Length];
            }

            for (int i = 0; i < lowerAlphabet.Length; i++)
            {
                cipherMap[lowerAlphabet[i]] = lowerAlphabet[(i + shift) % lowerAlphabet.Length];
            }
            char[] encryptedMessage = input.Select(c => cipherMap.ContainsKey(c) ? cipherMap[c] : c).ToArray();

            return new string(encryptedMessage);
        }
    }
}


