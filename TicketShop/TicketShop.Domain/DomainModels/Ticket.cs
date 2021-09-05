using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketShop.Domain.DomainModels
{
    public enum Genre
    {
        ACTION,
        COMEDY,
        THRILLER,
        HISTORY
    }
    public class Ticket : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public DateTime ValidDate { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public int Rating { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}
