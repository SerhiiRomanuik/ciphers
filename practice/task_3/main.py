##########################
## SCHEMA OF CARDANO GRILL
##  _____ _____
## |** **|00 00|
## |00 00|00 00|
## +_____+_____+
## |00 00|** **|
## |00 00|00 00|
## +_____+_____+

# def print_matrix(matrix):
#     n = 0
#     for row in range(4):
        
#         print('{:3}'.format(matrix[n]), end=' ')
#         for col in range(4):
#             n += 1
#             print('{:3}'.format(matrix[n]), end=' ')

def main():
    print("#### Cardano grill ####\n")
    matrix = [
    ["a", "b", "c", "a"],
     "b", "c","a", "b", "c", "a", "b", "c", "q", "a", "a", "a"]
    print(matrix)

if __name__ == '__main__':
    main()
    
