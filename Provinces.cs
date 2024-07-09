namespace Worker
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Seq { get; set; }
    }

    public class Model
    {
        public static List<Province> Provinces =
        [
            new Province{ Id = 1, Name = "Ha Noi", Lat = "21.0245", Lon = "105.8412", Seq = "10" },
            new Province{ Id = 2, Name = "Ha giang", Lat = "22.8274", Lon = "104.9866", Seq = "10" },
            new Province{ Id = 3, Name = "Cao Bang", Lat = "22.6667", Lon = "106.2588", Seq = "10" },
            new Province{ Id = 4, Name = "Lao Cai", Lat = "22.4997", Lon = "103.9657", Seq = "10" },
            new Province{ Id = 5, Name = "Son La", Lat = "21.3283", Lon = "103.9005", Seq = "10" },
            new Province{ Id = 6, Name = "Lai Chau", Lat = "22.3997", Lon = "103.4517", Seq = "10" },
            new Province{ Id = 7, Name = "Bac Kan", Lat = "22.1495", Lon = "105.8372", Seq = "10" },
            new Province{ Id = 8, Name = "Lang Son", Lat = "21.8505", Lon = "106.7662", Seq = "10" },
            new Province{ Id = 9, Name = "Tuyen Quang", Lat = "21.8233", Lon = "105.2181", Seq = "10" },
            new Province{ Id = 10, Name = "Yen Bai", Lat = "21.7026", Lon = "104.8714", Seq = "10" },
            new Province{ Id = 11, Name = "Thai Nguyen", Lat = "21.5928", Lon = "105.8442", Seq = "10" },
            new Province{ Id = 12, Name = "Dien Bien", Lat = "21.3833", Lon = "103.0167", Seq = "10" },
            new Province{ Id = 13, Name = "Phu Tho", Lat = "11.5486", Lon = "109.0281", Seq = "10" },
            new Province{ Id = 14, Name = "Vinh Phuc", Lat = "18.4169", Lon = "105.6954", Seq = "10" },
            new Province{ Id = 15, Name = "Bac Giang", Lat = "21.2779", Lon = "106.1939", Seq = "10" },
            new Province{ Id = 16, Name = "Bac Ninh", Lat = "21.1833", Lon = "106.05", Seq = "10" },
            new Province{ Id = 17, Name = "Quang Ninh", Lat = "20.9528", Lon = "107.08", Seq = "10" },
            new Province{ Id = 18, Name = "Hai Duong", Lat = "20.9333", Lon = "106.3167", Seq = "10" },
            new Province{ Id = 19, Name = "Hai Phong", Lat = "20.8561", Lon = "106.6822", Seq = "10" },
            new Province{ Id = 20, Name = "Hoa Binh", Lat = "20.813", Lon = "105.3453", Seq = "10" },
            new Province{ Id = 21, Name = "Hung Yen", Lat = "20.6491", Lon = "106.051", Seq = "10" },
            new Province{ Id = 22, Name = "Ha Nam", Lat = "16.3358", Lon = "107.7706", Seq = "10" },
            new Province{ Id = 23, Name = "Thai Binh", Lat = "20.4493", Lon = "106.3425", Seq = "10" },
            new Province{ Id = 24, Name = "Nam Dinh", Lat = "20.423", Lon = "106.1684", Seq = "10" },
            new Province{ Id = 25, Name = "Ninh Binh", Lat = "20.2545", Lon = "105.9765", Seq = "10" },
            new Province{ Id = 26, Name = "Thanh Hoa", Lat = "19.8", Lon = "105.7667", Seq = "10" },
            new Province{ Id = 27, Name = "Nghe An", Lat = "18.6667", Lon = "105.6667", Seq = "10" },
            new Province{ Id = 28, Name = "Ha Tinh", Lat = "18.3453", Lon = "105.9019", Seq = "10" },
            new Province{ Id = 29, Name = "Quang Binh", Lat = "17.4833", Lon = "106.6", Seq = "10" },
            new Province{ Id = 30, Name = "Quang Tri", Lat = "16.75", Lon = "107.2", Seq = "10" },
            new Province{ Id = 31, Name = "Hue", Lat = "16.4667", Lon = "107.6", Seq = "10" },
            new Province{ Id = 32, Name = "Da nang", Lat = "16.0678", Lon = "108.2208", Seq = "10" },
            new Province{ Id = 33, Name = "Quang Nam", Lat = "15.5757", Lon = "108.4743", Seq = "10" },
            new Province{ Id = 34, Name = "Quang Ngai", Lat = "15.1167", Lon = "108.8", Seq = "10" },
            new Province{ Id = 35, Name = "Kon Tum", Lat = "14.35", Lon = "108", Seq = "10" },
            new Province{ Id = 36, Name = "Gia Lai", Lat = "13.75", Lon = "108.25", Seq = "10" },
            new Province{ Id = 37, Name = "Binh Dinh", Lat = "13.886", Lon = "109.1117", Seq = "10" },
            new Province{ Id = 38, Name = "Phu Yen", Lat = "13.0833", Lon = "109.3", Seq = "10" },
            new Province{ Id = 39, Name = "Dak Lak", Lat = "12.6667", Lon = "108.05", Seq = "10" },
            new Province{ Id = 40, Name = "Khanh Hoa", Lat = "10.6765", Lon = "105.1903", Seq = "10" },
            new Province{ Id = 41, Name = "Dak Nong", Lat = "12.0085", Lon = "107.6901", Seq = "10" },
            new Province{ Id = 42, Name = "Lam Dong", Lat = "11.9402", Lon = "108.4376", Seq = "10" },
            new Province{ Id = 43, Name = "Ninh Thuan", Lat = "11.5653", Lon = "108.9886", Seq = "10" },
            new Province{ Id = 44, Name = "Binh Phuoc", Lat = "11.5333", Lon = "106.9167", Seq = "10" },
            new Province{ Id = 45, Name = "Tay Ninh", Lat = "11.3135", Lon = "106.096", Seq = "10" },
            new Province{ Id = 46, Name = "Binh Duong", Lat = "14.2972", Lon = "109.0797", Seq = "10" },
            new Province{ Id = 47, Name = "Dong Nai", Lat = "10.9569", Lon = "106.8536", Seq = "10" },
            new Province{ Id = 48, Name = "Binh Thuan", Lat = "10.9333", Lon = "108.1", Seq = "10" },
            new Province{ Id = 49, Name = "Ho Chi Minh", Lat = "10.75", Lon = "106.6667", Seq = "10" },
            new Province{ Id = 50, Name = "Long An", Lat = "10.6667", Lon = "106.1667", Seq = "10" },
            new Province{ Id = 51, Name = "Ba Ria Vung Tau", Lat = "10.4963", Lon = "107.1688", Seq = "10" },
            new Province{ Id = 52, Name = "Dong Thap", Lat = "10.462", Lon = "105.6358", Seq = "10" },
            new Province{ Id = 53, Name = "An Giang", Lat = "10.5", Lon = "105.1667", Seq = "10" },
            new Province{ Id = 54, Name = "Tien Giang", Lat = "10.35", Lon = "106.35", Seq = "10" },
            new Province{ Id = 55, Name = "Vinh Long", Lat = "10.2544", Lon = "105.967", Seq = "10" },
            new Province{ Id = 56, Name = "Ben Tre", Lat = "10.2448", Lon = "1106.3735", Seq = "10" },
            new Province{ Id = 57, Name = "Can Tho", Lat = "10.0333", Lon = "105.7833", Seq = "10" },
            new Province{ Id = 58, Name = "Kien Giang", Lat = "10.019", Lon = "105.0822", Seq = "10" },
            new Province{ Id = 59, Name = "Tra Vinh", Lat = "9.9356", Lon = "106.3398", Seq = "10" },
            new Province{ Id = 60, Name = "Hau Giang", Lat = "9.7579", Lon = "105.6410", Seq = "10" },
            new Province{ Id = 61, Name = "Soc Trang", Lat = "9.6081", Lon = "105.9715", Seq = "10" },
            new Province{ Id = 62, Name = "Bac Lieu", Lat = "9.2825", Lon = "105.7261", Seq = "10" },
            new Province{ Id = 63, Name = "Ca Mau", Lat = "9.1792", Lon = "105.1458", Seq = "10" }
        ];
    }
}
