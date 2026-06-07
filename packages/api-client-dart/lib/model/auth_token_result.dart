//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'auth_token_result.g.dart';

abstract class AuthTokenResult implements Built<AuthTokenResult, AuthTokenResultBuilder> {

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'accessToken')
    String get accessToken;

    @BuiltValueField(wireName: r'refreshToken')
    String get refreshToken;

    @BuiltValueField(wireName: r'expiresAt')
    DateTime get expiresAt;

    @BuiltValueField(wireName: r'mustChangePassword')
    bool get mustChangePassword;

    AuthTokenResult._();

    static void _initializeBuilder(AuthTokenResultBuilder b) => b;

    factory AuthTokenResult([void updates(AuthTokenResultBuilder b)]) = _$AuthTokenResult;

    @BuiltValueSerializer(custom: true)
    static Serializer<AuthTokenResult> get serializer => _$AuthTokenResultSerializer();
}

class _$AuthTokenResultSerializer implements StructuredSerializer<AuthTokenResult> {

    @override
    final Iterable<Type> types = const [AuthTokenResult, _$AuthTokenResult];
    @override
    final String wireName = r'AuthTokenResult';

    @override
    Iterable<Object> serialize(Serializers serializers, AuthTokenResult object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'accessToken')
            ..add(serializers.serialize(object.accessToken,
                specifiedType: const FullType(String)));
        result
            ..add(r'refreshToken')
            ..add(serializers.serialize(object.refreshToken,
                specifiedType: const FullType(String)));
        result
            ..add(r'expiresAt')
            ..add(serializers.serialize(object.expiresAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'mustChangePassword')
            ..add(serializers.serialize(object.mustChangePassword,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    AuthTokenResult deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AuthTokenResultBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'accessToken':
                    result.accessToken = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'refreshToken':
                    result.refreshToken = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'expiresAt':
                    result.expiresAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'mustChangePassword':
                    result.mustChangePassword = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

