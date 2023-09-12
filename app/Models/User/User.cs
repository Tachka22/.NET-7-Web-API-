using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace app.Models;

public class User
{


    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Key]
    public Guid Guid { get; set; }
    
    /// <summary>
    /// Уникальный Логин (запрещены все символы кроме латинских букв и цифр)
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль(запрещены все символы кроме латинских букв и цифр)
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// - Имя (запрещены все символы кроме латинских и русских букв)
    /// </summary>
    public string Name{ get; set; }
    
    /// <summary>
    /// Пол 0 - женщина, 1 - мужчина, 2 - неизвестно
    /// </summary>
    public int Gender { get; set; }
    
    /// <summary>
    /// поле даты рождения (может быть Null)
    /// </summary>
    public DateTime? BirthDay { get; set; }
    
    /// <summary>
    /// Является ли пользователь админом
    /// </summary>
    public bool Admin { get; set; }
    
    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTime CreatedOn { get; set; }
    
    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public string CreatedBy { get; set; }
    
    /// <summary>
    ///Дата изменения пользователя
    /// </summary>
    public DateTime ModifiedOn { get; set; }
    
    /// <summary>
    /// Логин Пользователя, от имени которого этот пользователь изменён
    /// </summary>
    public string ModifiedBy { get; set;}
    
    /// <summary>
    /// Дата удаления пользователя
    /// </summary>
    public DateTime RevokedOn {set; get; }
    
    /// <summary>
    /// Логин Пользователя, от имени которого этот пользователь удалён
    /// </summary>
    public string RevokedBy { get; set; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    /// <param name="guid">id</param>
    /// <param name="login">Логин</param>
    /// <param name="password">Пароль</param>
    /// <param name="name">Имя</param>
    /// <param name="gender">Пол</param>
    /// <param name="birthDay">Дата Рождения</param>
    /// <param name="admin">Админ</param>
    /// <param name="createdOn">Дата создания</param>
    /// <param name="createdBy">Кем создан</param>
    /// <param name="modifiedOn">Дата изменеия</param>
    /// <param name="modifiedBy">Кем изменён</param>
    /// <param name="revokedOn">Дата удаления пользователя</param>
    /// <param name="revokedBy">Кем удалён</param>
    /// <exception cref="ArgumentNullException"></exception>
    public User(Guid guid, string login, string password, string name, int gender, DateTime? birthDay, bool admin,
        DateTime createdOn, string createdBy, DateTime modifiedOn, string modifiedBy, DateTime revokedOn,
        string revokedBy)
    {
        #region Проверка
        
        if(!Regex.IsMatch(login,"^[a-zA-Z0-9]")) throw new ArgumentException("Invalid login");
        if(!Regex.IsMatch(password,"^[a-zA-Z0-9]")) throw new ArgumentException("Invalid password");
        if(!Regex.IsMatch(name,"^[a-zA-Z0-9]")) throw new ArgumentException("Invalid name");
        
        #endregion
        Guid = guid;
        Login = login ?? throw new ArgumentNullException(nameof(login));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Gender = gender;
        BirthDay = birthDay;
        Admin = admin;
        CreatedOn = createdOn;
        CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
        ModifiedOn = modifiedOn;
        ModifiedBy = modifiedBy ?? throw new ArgumentNullException(nameof(modifiedBy));
        RevokedOn = revokedOn;
        RevokedBy = revokedBy ?? throw new ArgumentNullException(nameof(revokedBy));
    }
}