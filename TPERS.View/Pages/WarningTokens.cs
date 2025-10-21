using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPERS.View.Pages;
public static class WarningTokens
{
    public static Tuple<string,string> Existing = new(
        "Já existe esse processo!",
        "Verifique os processos existentes!"
    );
    public static Tuple<string,string> Change = new(
        "Alterar processo?",
        "Essa ação não tem volta!"
    );
    public static Tuple<string,string> Delete = new(
        "Excluir processo?",
        "Essa ação não tem volta!"
    );
    public static Tuple<string,string> CreateSuccess = new(
        "Criado com sucesso!",
        "Criado com sucesso, já pode ser visto na lista"
    );
    public static Tuple<string,string> UpdateSuccess = new(
        "Alterado com sucesso!",
        "Alterado com sucesso, já pode ser visto na lista"
    );
}
