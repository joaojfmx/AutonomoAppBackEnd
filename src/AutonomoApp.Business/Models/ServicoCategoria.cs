using System;

namespace AutonomoApp.Business.Models;

public class ServicoCategoria : EntityBase
{
    public virtual Guid ServicoId { get; set; }
    public virtual Servico? Servico { get; set; }
    public virtual Guid CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }

}
public class ServicoSubCategoria : EntityBase
{
    public virtual Guid ServicoId { get; set; }
    public virtual Servico? Servico { get; set; }
    public virtual Guid SubCategoriaId { get; set; }
    public virtual Subcategoria? Subcategoria { get; set; }

}