package com.example.exemploeureka;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@EnableEurekaServer
@SpringBootApplication
public class ExemploEurekaApplication {

	public static void main(String[] args) {
		SpringApplication.run(ExemploEurekaApplication.class, args);
	}

}
