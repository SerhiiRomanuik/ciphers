import random
import re 

class bcolors:
    FAIL = '\033[91m'
    ENDC = '\033[0m'

def has_cyrillic(text):
    return bool(re.search('[\u0400-\u04FF]', text))

def content_function(letter):
    with open("letters", encoding = 'utf-8') as letters:
        content = letters.read().split(', ')
    n = content.index(letter)
    for a in range(n):
        content += [content.pop(0)]
    return content

def get_index_from_alph(letter):
    with open("letters", encoding = 'utf-8') as letters:
      content = letters.read().split(', ')
    n = content.index(letter)
    return n

def list_to_string(s):  
    str1 = "" 
    return (str1.join(s)) 

def main():
    print("#### Vigenère cipher ####\n")
    a, d, name, content, key, encryption, m, letter = 1, 1, [], [], [], [], 0, 'и'
    content = content_function(letter)

    while a > 0:
        name = input("\n#### ENTER NAME:~$ ").replace(" ", "")
        if has_cyrillic(name) == False:
            print(bcolors.FAIL + "\nERROR: ENTER CYRILLIC NAME!" + bcolors.ENDC)
        else:
            break

    len_name = len(name)

    for a in range(len_name):
        key += random.choice(content)
    print("#### ENCRYPTED KEY PAIR:~$ {}".format(list_to_string(key)))

    for x in range(len_name):
        letter = name[m]
        a = get_index_from_alph(letter)
        letter = key[m]
        b = content_function(letter)
        encryption += b[a]
        m +=1

    print("#### YOURS ECRYPTED NAME IS:~$ {}".format(list_to_string(encryption)))
    
    name, encryption, key, n, le = [], [], [], 0, 'а'

    while d > 0:
        retry = input("\n#### DO YOU WANT TO DECRYPT NAME?(Y/N):~$ ").replace(" ", "")
        if retry == 'Y':
            encryption = input("#### ENTER YOUR ENCRYPTION:~$ ").replace(" ", "")
            key = input("#### ENTER YOUR KEY:~$ ").replace(" ", "")

            len_encryption = len(encryption)
            for x in range(len_encryption):
                new_alph = content_function(key[n])
                new_index = new_alph.index(encryption[n])
                content = content_function(le)
                name += content[new_index]
                n += 1

        elif retry == 'N':
            exit()
        else:
            print(bcolors.FAIL + "\nERROR: ENTER 'Y' or 'N'" + bcolors.ENDC)
        print("#### YOUR NAME IS:~$ {}".format(list_to_string(name)))
        name, encryption, key, n, le = [], [], [], 0, 'а'
            
if __name__ == "__main__":
    main()
