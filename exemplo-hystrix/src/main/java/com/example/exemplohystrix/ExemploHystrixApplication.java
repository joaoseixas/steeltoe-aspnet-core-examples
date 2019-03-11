package com.example.exemplohystrix;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.hystrix.dashboard.EnableHystrixDashboard;

@SpringBootApplication
@EnableHystrixDashboard
public class ExemploHystrixApplication {

	public static void main(String[] args) {
		SpringApplication.run(ExemploHystrixApplication.class, args);
	}

}
