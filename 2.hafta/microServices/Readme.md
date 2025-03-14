# 2 Api Gateway ile yatay ölçeklendirme

![image](https://github.com/user-attachments/assets/970e0fd5-9268-4df0-b84c-d91973773d7d)

### Nginx load balancer 80 portuna gelen istekleri Ocelot ile oluşturulan uygun bir api gateway'e iletiyor. 5004 portu olanlar ApiGatewayBlue'ya; 5005 portu olanlar ApiGatewayRed'e iletiliyor

![image](https://github.com/user-attachments/assets/01b93053-a309-4644-9ee8-00085ee46ea1)

![Screenshot_5](https://github.com/user-attachments/assets/9c23f2d6-0cde-4bfa-920c-8c34c3160c32)

### Eğer bir api gateway de sorun oluşursa diğerine yönlendiriyor. Load Balancer api gateway olorak sadece ApiGatewayRed'i(port:5005) çalıştırdım ve aşağıda görüldüğü gibi ApiGatewayBlue(port:5004) ulaşamadığı için sadece ApiGatewayRed'i kullandı.

![Screenshot_6](https://github.com/user-attachments/assets/ef2fdb58-d464-46e9-ac4c-adbe2218e6b2)


