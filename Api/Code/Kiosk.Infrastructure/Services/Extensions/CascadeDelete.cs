// using System.Collections;
// using Kiosk.Domain.Models;
// using Kiosk.Infrastructure.Tables;
// using Microsoft.EntityFrameworkCore;

// namespace Kiosk.Infrastructure.Services.Extensions;

// public static class CascadeDeleteExtension
// {
//     public static BaseModel CascadeDelete<T>(this DbSet<T> dbset, BaseModel entitie) where T : BaseModel
//     {   
//         // entitie.DisabledAt = DateTime.UtcNow;

//         // var properties = entitie
//         //     .GetType()
//         //     .GetProperties()
//         //     .Where(p =>
//         //         p.PropertyType.IsGenericType &&
//         //         typeof(IEnumerable).IsAssignableFrom(p.PropertyType) &&
//         //         typeof(BaseModel).IsAssignableFrom(p.PropertyType.GetGenericArguments()[0]))
//         //     .ToList();
        
//         // foreach(var prop in properties)
//         // {
//         //     var values = prop.GetValue(entitie) as IEnumerable;
//         //     if (values == null) continue;

//         //     foreach (var child in values)
            
//         //         if(child is BaseModel item)
//         //             CascadeDelete(dbset, item);
//         // }

//         // return entitie;

//         //=============================================================================================================

//         // var entry = ctx.Entry(entitie);
//         // entry.State = EntityState.Modified;
//         // ((BaseModel)entry.Entity).DisabledAt = DateTime.UtcNow;
//         // Console.WriteLine("\n\n\n");
//         // Console.WriteLine("!!!!!!!!!!!!!!!!!");
//         // Console.WriteLine("");
//         // Console.WriteLine("!!!!!!!!!!!!!!!!!");
//         // foreach(var nav in entry.Navigations)
//         //     if(nav.CurrentValue is IEnumerable children)
//         //         foreach(var c in children)
//         //             if(c is BaseModel bc)
//         //             {
//         //                 var entryC = Entry(bc);
//         //                 CascadeSoftDelete(entryC);
//         //             }
//     }
// }