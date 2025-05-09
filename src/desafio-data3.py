def calcular_moda(lista):
    frequencias = {}
    for num in lista:
        if num in frequencias:
            frequencias[num] += 1
        else:
            frequencias[num] = 1
    
    maior_frequencia = max(frequencias.values())
    modas = [num for num, freq in frequencias.items() if freq == maior_frequencia]
    
    return modas

entrada = input()
dados = list(map(int, entrada.split()))

modas = calcular_moda(dados)

if len(modas) > 1:
    print(" ".join(map(str, modas)))
else:
    print(modas[0])