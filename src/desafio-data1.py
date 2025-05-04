data_input = input()

def converter_para_dia_mes_ano(data_str):
    ano, dia, mes = data_str.split("-")
    return f"{dia}/{mes}/{ano}"

if "-" in data_input:
    print(converter_para_dia_mes_ano(data_input))
else:
    print("Formato de data inválido")