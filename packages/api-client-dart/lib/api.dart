//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

library mansis_pos_api_client.api;

import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';
import 'package:mansis_pos_api_client/serializers.dart';
import 'package:mansis_pos_api_client/auth/api_key_auth.dart';
import 'package:mansis_pos_api_client/auth/basic_auth.dart';
import 'package:mansis_pos_api_client/auth/oauth.dart';
import 'package:mansis_pos_api_client/api/admin_api.dart';
import 'package:mansis_pos_api_client/api/app_api.dart';
import 'package:mansis_pos_api_client/api/auth_api.dart';
import 'package:mansis_pos_api_client/api/loyalty_api.dart';
import 'package:mansis_pos_api_client/api/reports_api.dart';
import 'package:mansis_pos_api_client/api/stock_api.dart';


final _defaultInterceptors = [
  OAuthInterceptor(),
  BasicAuthInterceptor(),
  ApiKeyAuthInterceptor(),
];

class MansisPosApiClient {

    static const String basePath = r'https://api.example.com';

    final Dio dio;

    final Serializers serializers;

    MansisPosApiClient({
      Dio dio,
      Serializers serializers,
      String basePathOverride,
      List<Interceptor> interceptors,
    })  : this.serializers = serializers ?? standardSerializers,
          this.dio = dio ??
              Dio(BaseOptions(
                baseUrl: basePathOverride ?? basePath,
                connectTimeout: 5000,
                receiveTimeout: 3000,
              )) {
      if (interceptors == null) {
        this.dio.interceptors.addAll(_defaultInterceptors);
      } else {
        this.dio.interceptors.addAll(interceptors);
      }
    }

    void setOAuthToken(String name, String token) {
        (this.dio.interceptors.firstWhere((element) => element is OAuthInterceptor, orElse: null) as OAuthInterceptor)?.tokens[name] = token;
    }

    void setBasicAuth(String name, String username, String password) {
        (this.dio.interceptors.firstWhere((element) => element is BasicAuthInterceptor, orElse: null) as BasicAuthInterceptor)?.authInfo[name] = BasicAuthInfo(username, password);
    }

    void setApiKey(String name, String apiKey) {
        (this.dio.interceptors.firstWhere((element) => element is ApiKeyAuthInterceptor, orElse: null) as ApiKeyAuthInterceptor)?.apiKeys[name] = apiKey;
    }


    /**
    * Get AdminApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    AdminApi getAdminApi() {
    return AdminApi(dio, serializers);
    }


    /**
    * Get AppApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    AppApi getAppApi() {
    return AppApi(dio, serializers);
    }


    /**
    * Get AuthApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    AuthApi getAuthApi() {
    return AuthApi(dio, serializers);
    }


    /**
    * Get LoyaltyApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    LoyaltyApi getLoyaltyApi() {
    return LoyaltyApi(dio, serializers);
    }


    /**
    * Get ReportsApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    ReportsApi getReportsApi() {
    return ReportsApi(dio, serializers);
    }


    /**
    * Get StockApi instance, base route and serializer can be overridden by a given but be careful,
    * by doing that all interceptors will not be executed
    */
    StockApi getStockApi() {
    return StockApi(dio, serializers);
    }


}
