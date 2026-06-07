//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_dto.g.dart';

abstract class CustomerDto implements Built<CustomerDto, CustomerDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'surname')
    String get surname;

    @BuiltValueField(wireName: r'username')
    String get username;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'balance')
    double get balance;

    @BuiltValueField(wireName: r'active')
    bool get active;

    CustomerDto._();

    static void _initializeBuilder(CustomerDtoBuilder b) => b;

    factory CustomerDto([void updates(CustomerDtoBuilder b)]) = _$CustomerDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerDto> get serializer => _$CustomerDtoSerializer();
}

class _$CustomerDtoSerializer implements StructuredSerializer<CustomerDto> {

    @override
    final Iterable<Type> types = const [CustomerDto, _$CustomerDto];
    @override
    final String wireName = r'CustomerDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'surname')
            ..add(serializers.serialize(object.surname,
                specifiedType: const FullType(String)));
        result
            ..add(r'username')
            ..add(serializers.serialize(object.username,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(object.phone == null ? null : serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        result
            ..add(r'mail')
            ..add(object.mail == null ? null : serializers.serialize(object.mail,
                specifiedType: const FullType(String)));
        result
            ..add(r'balance')
            ..add(serializers.serialize(object.balance,
                specifiedType: const FullType(double)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    CustomerDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'surname':
                    result.surname = serializers.deserialize(value,
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
                case r'balance':
                    result.balance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

