//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'user_write.g.dart';

abstract class UserWrite implements Built<UserWrite, UserWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'firstName')
    String get firstName;

    @BuiltValueField(wireName: r'lastName')
    String get lastName;

    @BuiltValueField(wireName: r'username')
    String get username;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'roleId')
    String get roleId;

    @nullable
    @BuiltValueField(wireName: r'cardId')
    String get cardId;

    @nullable
    @BuiltValueField(wireName: r'pin')
    String get pin;

    @nullable
    @BuiltValueField(wireName: r'password')
    String get password;

    @BuiltValueField(wireName: r'mustChangePassword')
    bool get mustChangePassword;

    @BuiltValueField(wireName: r'branchIds')
    BuiltList<String> get branchIds;

    @BuiltValueField(wireName: r'posIds')
    BuiltList<String> get posIds;

    @BuiltValueField(wireName: r'storeIds')
    BuiltList<String> get storeIds;

    UserWrite._();

    static void _initializeBuilder(UserWriteBuilder b) => b;

    factory UserWrite([void updates(UserWriteBuilder b)]) = _$UserWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<UserWrite> get serializer => _$UserWriteSerializer();
}

class _$UserWriteSerializer implements StructuredSerializer<UserWrite> {

    @override
    final Iterable<Type> types = const [UserWrite, _$UserWrite];
    @override
    final String wireName = r'UserWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, UserWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'firstName')
            ..add(serializers.serialize(object.firstName,
                specifiedType: const FullType(String)));
        result
            ..add(r'lastName')
            ..add(serializers.serialize(object.lastName,
                specifiedType: const FullType(String)));
        result
            ..add(r'username')
            ..add(serializers.serialize(object.username,
                specifiedType: const FullType(String)));
        if (object.phone != null) {
            result
                ..add(r'phone')
                ..add(serializers.serialize(object.phone,
                    specifiedType: const FullType(String)));
        }
        if (object.mail != null) {
            result
                ..add(r'mail')
                ..add(serializers.serialize(object.mail,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'roleId')
            ..add(serializers.serialize(object.roleId,
                specifiedType: const FullType(String)));
        if (object.cardId != null) {
            result
                ..add(r'cardId')
                ..add(serializers.serialize(object.cardId,
                    specifiedType: const FullType(String)));
        }
        if (object.pin != null) {
            result
                ..add(r'pin')
                ..add(serializers.serialize(object.pin,
                    specifiedType: const FullType(String)));
        }
        if (object.password != null) {
            result
                ..add(r'password')
                ..add(serializers.serialize(object.password,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'mustChangePassword')
            ..add(serializers.serialize(object.mustChangePassword,
                specifiedType: const FullType(bool)));
        result
            ..add(r'branchIds')
            ..add(serializers.serialize(object.branchIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        result
            ..add(r'posIds')
            ..add(serializers.serialize(object.posIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        result
            ..add(r'storeIds')
            ..add(serializers.serialize(object.storeIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    UserWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = UserWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'firstName':
                    result.firstName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'lastName':
                    result.lastName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'username':
                    result.username = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'mail':
                    result.mail = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'roleId':
                    result.roleId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'cardId':
                    result.cardId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'pin':
                    result.pin = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'password':
                    result.password = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'mustChangePassword':
                    result.mustChangePassword = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'branchIds':
                    result.branchIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
                case r'posIds':
                    result.posIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
                case r'storeIds':
                    result.storeIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

