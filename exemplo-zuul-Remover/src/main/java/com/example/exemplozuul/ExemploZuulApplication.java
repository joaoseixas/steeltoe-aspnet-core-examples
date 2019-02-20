package com.example.exemplozuul;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.zuul.EnableZuulProxy;

@EnableZuulProxy
@SpringBootApplication
public class ExemploZuulApplication {

	public static void main(String[] args) {
		SpringApplication.run(ExemploZuulApplication.class, args);
	}

}
