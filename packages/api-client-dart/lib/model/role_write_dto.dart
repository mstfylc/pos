//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'role_write_dto.g.dart';

abstract class RoleWriteDto implements Built<RoleWriteDto, RoleWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    RoleWriteDto._();

    static void _initializeBuilder(RoleWriteDtoBuilder b) => b;

    factory RoleWriteDto([void updates(RoleWriteDtoBuilder b)]) = _$RoleWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<RoleWriteDto> get serializer => _$RoleWriteDtoSerializer();
}

class _$RoleWriteDtoSerializer implements StructuredSerializer<RoleWriteDto> {

    @override
    final Iterable<Type> types = const [RoleWriteDto, _$RoleWriteDto];
    @override
    final String wireName = r'RoleWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, RoleWriteDto object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    RoleWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RoleWriteDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

