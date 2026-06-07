//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'address_write_dto.g.dart';

abstract class AddressWriteDto implements Built<AddressWriteDto, AddressWriteDtoBuilder> {

    @nullable
    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'addressType')
    int get addressType;

    @nullable
    @BuiltValueField(wireName: r'addressHeader')
    String get addressHeader;

    @BuiltValueField(wireName: r'cityId')
    String get cityId;

    @BuiltValueField(wireName: r'townId')
    String get townId;

    @nullable
    @BuiltValueField(wireName: r'district')
    String get district;

    @nullable
    @BuiltValueField(wireName: r'mobilePhone')
    String get mobilePhone;

    @nullable
    @BuiltValueField(wireName: r'businessPhone')
    String get businessPhone;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    AddressWriteDto._();

    static void _initializeBuilder(AddressWriteDtoBuilder b) => b;

    factory AddressWriteDto([void updates(AddressWriteDtoBuilder b)]) = _$AddressWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<AddressWriteDto> get serializer => _$AddressWriteDtoSerializer();
}

class _$AddressWriteDtoSerializer implements StructuredSerializer<AddressWriteDto> {

    @override
    final Iterable<Type> types = const [AddressWriteDto, _$AddressWriteDto];
    @override
    final String wireName = r'AddressWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, AddressWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(object.id == null ? null : serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'addressType')
            ..add(serializers.serialize(object.addressType,
                specifiedType: const FullType(int)));
        result
            ..add(r'addressHeader')
            ..add(object.addressHeader == null ? null : serializers.serialize(object.addressHeader,
                specifiedType: const FullType(String)));
        result
            ..add(r'cityId')
            ..add(serializers.serialize(object.cityId,
                specifiedType: const FullType(String)));
        result
            ..add(r'townId')
            ..add(serializers.serialize(object.townId,
                specifiedType: const FullType(String)));
        result
            ..add(r'district')
            ..add(object.district == null ? null : serializers.serialize(object.district,
                specifiedType: const FullType(String)));
        result
            ..add(r'mobilePhone')
            ..add(object.mobilePhone == null ? null : serializers.serialize(object.mobilePhone,
                specifiedType: const FullType(String)));
        result
            ..add(r'businessPhone')
            ..add(object.businessPhone == null ? null : serializers.serialize(object.businessPhone,
                specifiedType: const FullType(String)));
        result
            ..add(r'description')
            ..add(object.description == null ? null : serializers.serialize(object.description,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    AddressWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AddressWriteDtoBuilder();

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
                case r'addressType':
                    result.addressType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'addressHeader':
                    result.addressHeader = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'cityId':
                    result.cityId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'townId':
                    result.townId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'district':
                    result.district = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'mobilePhone':
                    result.mobilePhone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'businessPhone':
                    result.businessPhone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

