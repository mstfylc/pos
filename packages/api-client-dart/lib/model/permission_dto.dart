//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'permission_dto.g.dart';

abstract class PermissionDto implements Built<PermissionDto, PermissionDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'displayName')
    String get displayName;

    @BuiltValueField(wireName: r'permissionType')
    int get permissionType;

    PermissionDto._();

    static void _initializeBuilder(PermissionDtoBuilder b) => b;

    factory PermissionDto([void updates(PermissionDtoBuilder b)]) = _$PermissionDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PermissionDto> get serializer => _$PermissionDtoSerializer();
}

class _$PermissionDtoSerializer implements StructuredSerializer<PermissionDto> {

    @override
    final Iterable<Type> types = const [PermissionDto, _$PermissionDto];
    @override
    final String wireName = r'PermissionDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PermissionDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'displayName')
            ..add(object.displayName == null ? null : serializers.serialize(object.displayName,
                specifiedType: const FullType(String)));
        result
            ..add(r'permissionType')
            ..add(serializers.serialize(object.permissionType,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    PermissionDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PermissionDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'displayName':
                    result.displayName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'permissionType':
                    result.permissionType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

