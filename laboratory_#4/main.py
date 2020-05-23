
upperCased = list(map(chr, range(ord('A'), ord('Z')+1)))  	# A, B, C, ..., Z
lowerCased = list(map(chr, range(ord('a'), ord('z')+1))) 		# a, b, c, ..., z
otherSymbols = [' ', '?', '!', '.', ':', '-', '_', '(', ')']
Alphabet = upperCased + lowerCased + otherSymbols

def main(): 
	
	print( "#### Affine Cipher ####" )

	clearText = input("\n#### ENTER NAME:~$ ").replace(" ", "")
	
	cipherText = cipher(clearText, 5, 7)
	print( "#### Encrypted Text: {0}".format(cipherText))
	
	decipherText = decipher(cipherText, 5, 7)
	print( "#### Decrypted Text: {0}".format(decipherText))
	
	return
	
def hcf( a, b ): return a if b == 0 else hcf( b, a % b )

def areRelativePrimes( a, b ): return hcf( a, b ) == 1

def getMultiplicativeInverse( a ):
	
	result = 1
	
	for i in range( 1, len( Alphabet ) ):
		
		if (a * i) % len( Alphabet ) == 1:
			
			result = i
	
	return result

def cipher(clearText, a, b):
  
	# gate 
	if ( a < 1 or a > len(Alphabet) ):
		return "'a' must be in the interval [1,{0}]".format( len(Alphabet) )

	if ( b < 1 or b > len(Alphabet) ):
		return "'b' must be in the interval [1,{0}]".format( len(Alphabet) )
	
	if ( not areRelativePrimes( a, len(Alphabet)) ):
		return "'a' must be relatively prime to {0}".format( len(Alphabet) )
	
	# body
	result = ""
	
	m = len( Alphabet )
	
	for pChar in clearText:
		
		p = Alphabet.index( pChar )
		
		c = a * p + b % m
		cIdx = c % len( Alphabet )
		cChar = Alphabet[ cIdx ]
		
		result += cChar
	
	return result
  
def decipher(cipherText, a, b):
  
	# gate 
	if ( a < 1 or a > len(Alphabet) ):
		return "'a' must be in the interval [1,{0}]".format( len(Alphabet) )

	if ( b < 1 or b > len(Alphabet) ):
		return "'b' must be in the interval [1,{0}]".format( len(Alphabet) )
	
	if ( not areRelativePrimes( a, len(Alphabet)) ):
		return "'a' must be relatively prime to {0}".format( len(Alphabet) )
	
	# body
	result = ""
	
	m = len( Alphabet )
	
	for cChar in cipherText:
		
		c = Alphabet.index( cChar )
		
		aInverse = getMultiplicativeInverse( a )
		pIdx = aInverse * (c - b) % len( Alphabet )
		if pIdx < 0:
			pIdx += len( Alphabet )
		
		pChar = Alphabet[ pIdx ]
		
		result += pChar
	
	return result
	
main()
