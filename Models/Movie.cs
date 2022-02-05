using System.ComponentModel.DataAnnotations;

namespace bertozzi.mattia._5H.WebCRUD.Models;
public class Movie
{
    public int Id { get; set; }


    [Display(Name= "Titolo",Prompt ="Inserire il Titolo", Description ="Titolo del film")]
    public string? Title { get; set; }


    [Display(Name= "Data di Uscita",Prompt ="Inserire Data di Pubblicazione", Description ="Data di Pubblicazione del film")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }


    [Display(Name= "Genere",Prompt ="Inserire il Genere", Description ="Genere del film")]
    public string? Genre { get; set; }


    [Display(Name= "Prezzo",Prompt ="Inserire il Prezzo", Description ="Prezzo del film in euro")]
    public decimal Price { get; set; }
}   